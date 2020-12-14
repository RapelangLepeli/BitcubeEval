using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Training_Facility.Model
{
    public class Degree
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public List<Course> Courses { get; set; }
        public Lecturer lecturer { get; set; }
        public Degree()
        {
            Courses = new List<Course>();
        }
    }
}
