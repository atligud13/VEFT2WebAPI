using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebAPI.Services.Entities
{
    /// <summary>
    /// A mapping class that takes care of maintaining
    /// which students are in which courses.
    /// </summary>
    class CourseRegistration
    {
        /// <summary>
        /// The ID of this registration
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The ID of the student
        /// </summary>
        public int StudentID { get; set; }

        /// <summary>
        /// The ID of the course.
        /// </summary>
        public int CourseID { get; set; }
    }
}
