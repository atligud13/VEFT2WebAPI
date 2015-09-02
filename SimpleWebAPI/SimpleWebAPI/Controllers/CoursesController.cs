using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SimpleWebAPI.Models;
using System.Web.Http.Description;
using SimpleWebAPI.Services;
using System.Data.Entity.Core;

namespace SimpleWebAPI.Controllers
{
    


    /// <summary>
    /// Courses is the main resource for course instances, i.e. a course
    /// which is taught on a given semester. For simplicity, the term
    /// "course" will always refer to an instance of a course in the
    /// documentation.
    /// </summary>
    [RoutePrefix("api/v1/courses")]
    public class CoursesController : ApiController
    {
  
        private readonly CoursesServiceProvider _service;

        /// <summary>
        /// Constructor, initializes all services.
        /// </summary>
        public CoursesController()
        {
            _service = new CoursesServiceProvider();
        }

        /// <summary>
        /// Returns a list of all courses
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public List<CourseDTO> GetCourses(string semester = null){
            return _service.GetCoursesBySemester(semester);
        }

        /// <summary>
        /// Returns a single course with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}", Name = "GetCourse")]
        public CourseDTO GetCourseById(int id)
        {
            try
            {
                return _service.GetCourseByID(id);
            }
            catch(ObjectNotFoundException)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        /// Adds a new course to the list
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(CourseDTO))]
        public IHttpActionResult AddCourse(CourseViewModel newCourse)
        {
            CourseDTO course;
            try
            {
                course = _service.AddCourse(newCourse);
            }
            catch(ObjectNotFoundException)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var location = Url.Link("GetCourse", new { id = course.ID });

            return Created(location, course);
        }

        /// <summary>
        /// Updates the course with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newCourse"></param>
        /// <returns></returns>
        [HttpPut]
        [ResponseType(typeof(CourseDTO))]
        [Route("{id:int}")]
        public IHttpActionResult UpdateCourse(int id, CourseViewModel newCourse)
        {
            try
            {
                _service.UpdateCourse(id, newCourse);
            }
            catch(ObjectNotFoundException)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Ok();
        }

        /// <summary>
        /// Deletes the course with the given ID
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("{id:int}")]
        public void DeleteCourse(int id)
        {
            try
            {
                _service.DeleteCourse(id);
            }
            catch(ObjectNotFoundException)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        /// Returns the student list from a course with the given ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}/students", Name = "GetStudents")]
        public List<StudentDTO> GetStudents(int id)
        {
            try
            {
                return _service.GetStudentsByCourseID(id);
            }
            catch(ObjectNotFoundException)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        /// Adds the student to the course with the given id
        /// </summary>
        /// <param name="courseID"></param>
        /// <param name="newStudent"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id:int}/students")]
        public IHttpActionResult AddStudent(int courseID, StudentViewModel newStudent)
        {
            StudentDTO student;
            try
            {
                student = _service.AddStudentToCourse(courseID, newStudent);
            }
            catch(ObjectNotFoundException)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var location = Url.Link("GetStudent", new { courseID = courseID, studentID = student.ID });

            return Created(location, student) ;
        }
    }
}
