﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SimpleWebAPI.Models;
using System.Web.Http.Description;
using SimpleWebAPI.Services;
using SimpleWebAPI.Services.Exceptions;
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
        public CourseDetailsDTO GetCourseById(int id)
        {
            try
            {
                return _service.GetCourseByID(id);
            }
            catch(CourseNotFoundException)
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
        public IHttpActionResult AddCourse(AddCourseViewModel newCourse)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CourseDetailsDTO course = _service.AddCourse(newCourse);
                    var location = Url.Link("GetCourse", new { id = course.ID });

                    return Created(location, course);
                }
                catch(CourseNotFoundException)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
            else
            {
                return StatusCode(HttpStatusCode.PreconditionFailed);
            }
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
        public IHttpActionResult UpdateCourse(int id, UpdateCourseViewModel newCourse)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.UpdateCourse(id, newCourse);
                    return Ok();
                }
                catch (CourseNotFoundException)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
            else
            {
                return StatusCode(HttpStatusCode.PreconditionFailed);
            }
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
            catch(CourseNotFoundException)
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
            catch(CourseNotFoundException)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        /// Adds the student to the course with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newStudent"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id:int}/students")]
        public IHttpActionResult AddStudent(int id, StudentViewModel newStudent)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    StudentDTO student = _service.AddStudentToCourse(id, newStudent);
                    return Content(HttpStatusCode.Created, student);
                }
                catch (CourseNotFoundException)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                catch (StudentNotFoundException)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
            else
            {
                return StatusCode(HttpStatusCode.PreconditionFailed);
            }
        }
    }
}
