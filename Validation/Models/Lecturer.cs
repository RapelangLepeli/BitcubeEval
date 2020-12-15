using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Validation.Models
{
    public class Lecturer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public string EmailAddress { get; set; }

        public List<Student> Students = new List<Student>();
        public List<Degree> Degrees = new List<Degree>();
    }
}
