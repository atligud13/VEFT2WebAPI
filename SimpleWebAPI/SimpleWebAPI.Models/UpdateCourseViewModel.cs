using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebAPI.Models
{
    public class UpdateCourseViewModel
    {
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
