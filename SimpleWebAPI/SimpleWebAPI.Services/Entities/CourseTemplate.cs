using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebAPI.Services.Entities
{
    /// <summary>
    /// A mapping class used to find the name of 
    /// a course from it's course ID.
    /// </summary>
    class CourseTemplate
    {
        /// <summary>
        /// Specifies the name of this course
        /// For example: Web Services
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Specifies the course ID of this course
        /// For example: T-514-VEFT
        /// </summary>
        public string CourseID { get; set; }
    }
}
