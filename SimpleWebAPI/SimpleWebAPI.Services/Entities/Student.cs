using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebAPI.Services.Entities
{
    class Student
    {
        /// <summary>
        /// Database ID for this student
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Social security number of this student
        /// </summary>
        public string SSN { get; set; }

        /// <summary>
        /// The name of this student
        /// </summary>
        public string Name { get; set; }
    }
}
