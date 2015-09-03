using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleWebAPI.Services.Entities
{
    [Table("Courses")]
    class Course
    {
        /// <summary>
        /// Database ID for this course
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Template ID of this course
        /// For example: T-514-VEFT
        /// </summary>
        public string TemplateID { get; set; }

        /// <summary>
        /// Start date of this course
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End date of this course
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Specifies which semester this particular course is in.
        /// For example: 20153 would mean that it the course is 
        /// from the year 2015, and it's the third semester of the year.
        /// With Spring being first, summer second and autumn third, 
        /// 20153 would mean Autumn 2015.
        /// </summary>
        public string Semester { get; set; }
    }
}
