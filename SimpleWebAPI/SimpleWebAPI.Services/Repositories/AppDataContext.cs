using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SimpleWebAPI.Services.Entities;

namespace SimpleWebAPI.Services.Repositories
{
    class AppDataContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
    }
}
