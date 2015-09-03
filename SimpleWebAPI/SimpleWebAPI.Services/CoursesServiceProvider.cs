using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWebAPI.Models;
using SimpleWebAPI.Services.Repositories;

namespace SimpleWebAPI.Services
{
    public class CoursesServiceProvider
    {
        private readonly AppDataContext _db;

        public CoursesServiceProvider()
        {
            _db = new AppDataContext();
        }

        /// <summary>
        /// Returns a list of courses for a given semester.
        /// If no semester is provided, the current semester
        /// will be provided.
        /// </summary>
        /// <param name="semester"></param>
        /// <returns></returns>
        public List<CourseDTO> GetCoursesBySemester(string semester = null)
        {
            if (string.IsNullOrEmpty(semester))
            {
                semester = "20153";
            }

            StudentDTO student = new StudentDTO
            {
                ID = 1,
                Name = "Atli",
                SSN = "124"
            };
            List<StudentDTO> students = new List<StudentDTO>();
            students.Add(student);

            var result = (from c in _db.Courses
                          select new CourseDTO
                          {
                              ID = c.ID,
                              Name = "",
                              StartDate = c.StartDate,
                              TemplateID = c.TemplateID,
                              EndDate = c.EndDate
                          }).ToList();

            return result;
        }

        /// <summary>
        /// Returns a single course with the specified ID
        /// If no course is found then an object not found exception
        /// is thrown.
        /// </summary>
        /// <param name="courseModel"></param>
        /// <returns></returns>
        public CourseDTO GetCourseByID(int ID)
        {
            /*
            var course = _courses.Find(x => id == x.ID);
            if (course == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return course;
            */
            return null;
        }

        /// <summary>
        /// Adds the course to the list of courses.
        /// If an entry for the given CourseID does not exist 
        /// in the course template list, an object not found exception is thrown.
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public CourseDTO AddCourse(CourseViewModel course)
        {
            return null;
        }

        /// <summary>
        /// Updates the course with the given ID, if a course
        /// with the given ID was not found then null an object not 
        /// found exception is thrown.
        /// </summary>
        /// <returns></returns>
        public CourseDTO UpdateCourse(int ID, CourseViewModel course)
        {
            /*
            // Checking if the object is not valid
            if (newCourse == null) throw new HttpResponseException(HttpStatusCode.PreconditionFailed);
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.PreconditionFailed);

            // Finding the course
            var course = _courses.Find(x => newCourse.ID == x.ID);
            if (course == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            //Course was found, updating it
            course.Name = newCourse.Name;
            course.TemplateID = newCourse.TemplateID;
            course.StartDate = newCourse.StartDate;
            course.EndDate = newCourse.EndDate;
            return Ok();
            */
            return null;
        }

        /// <summary>
        /// Deletes the course with the given ID.
        /// If a course with the given ID was not found then
        /// an object not found exception is thrown.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public void DeleteCourse(int ID)
        {
            /*
            // Finding the course
            var course = _courses.Find(x => id == x.ID);
            if (course == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            // Course was found, deleting it
            _courses.Remove(course);

            // Void returns 204
            */
        }

        /// <summary>
        /// Returns a list of students signed up for the course
        /// with the given ID. If no students are signed up for the course
        /// an empty list should be returned.
        /// If no course is found for the given ID, en error is thrown.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public List<StudentDTO> GetStudentsByCourseID(int ID)
        {
            /*
            // Finding the course
            var course = _courses.Find(x => id == x.ID);
            if (course == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            // Course was found, returning the student list
            return course.Students;
            */
            return null;
        }

        /// <summary>
        /// Adds the student to the course with the given ID
        /// If no course/student is found, an Object not found exception is thrown.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public StudentDTO AddStudentToCourse(int courseID, StudentViewModel student)
        {
            /*
            // Checking if the object is not valid
            if (newStudent == null) throw new HttpResponseException(HttpStatusCode.PreconditionFailed);
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.PreconditionFailed);

            // Finding the course
            var course = _courses.Find(x => id == x.ID);
            if (course == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            // Course was found, creating the student and adding 
            // it to the user list
            Student student = new Student
            {
                SSN = newStudent.SSN,
                Name = newStudent.Name
            };
            course.Students.Add(student);
            var location = Url.Link("GetStudents", new { id = course.ID });
            return Created(location, student);
            */
            return null;
        }
    }
}
