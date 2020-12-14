using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Training_Facility.Model
{
    public interface IPerson
    {
        [Key]
        public int ID { get; set; }
        string ForeNames { get; set; }
        string Surname { get; set; }
        string EmailAddress { get; set; }
        DateTime DateOfBirth { get; set; }
        string FirstName { get; }
        string FullName { get; }
    }
    public class Lecturer : Person
    {
        public List<Degree> degrees { get; set; }
        public List<Course> courses { get; set; }
        public List<Student> students { get; set; }
        public Lecturer()
        {
            degrees = new List<Degree>();
            courses = new List<Course>();
            students = new List<Student>();
        }
        public IEnumerator<Course> GetEnumerator()
        {
            foreach (var item in courses)
            {
                yield return item;
            }
        }
        public IEnumerator<Degree> GetEnumerator1()
        {
            foreach (var item in degrees)
            {
                yield return item;
            }
        }
    }

    public class Student : Person
    {
        public Degree degree { get; set; }
    }

    public class Person : IPerson
    {
        [Key]
        public int ID { get; set; }
        public string ForeNames { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FirstName
        {
            get
            {
                string[] names = ForeNames.Split(" ");
                return names[0];
            }
        }
        public string FullName
        {
            get
            {
                return ForeNames + Surname;
            }
        }
    }


}
