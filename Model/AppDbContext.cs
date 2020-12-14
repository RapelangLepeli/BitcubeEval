using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training_Facility.Model
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
        public DbSet<Lecturer> Lecturer { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Degree> Degree { get; set; }
        public DbSet<Course> Course { get; set; }
    }
}
