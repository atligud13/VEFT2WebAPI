using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebAPI.Models
{
    public class CourseViewModel
    {
        /// <summary>
        /// Course ID of this course
        /// For example: T-514-VEFT
        /// </summary>
        public string CourseID { get; set; }

        /// <summary>
        /// Specifies which semester this particular course is in.
        /// For example: 20153 would mean that it the course is 
        /// from the year 2015, and it's the third semester of the year.
        /// With Spring being first, summer second and autumn third, 
        /// 20153 would mean Autumn 2015.
        /// </summary>
        public string Semester { get; set; }

        /// <summary>
        /// Start date of this course
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End date of this course
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
