using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Training_Facility.Model
{
    public class Course
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public Degree degree { get; set; }

        public List<Course> Courses { get; set; }

        public Course()
        {
            Courses = new List<Course>();

        }
    }

}
