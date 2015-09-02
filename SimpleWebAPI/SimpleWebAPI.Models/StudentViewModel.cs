using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebAPI.Models
{
    public class StudentViewModel
    {
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
