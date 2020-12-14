using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Training_Facility.Model;

namespace Training_Facility.Pages.CourseList
{
    public class EditModel : PageModel
    {
        private AppDbContext data;

        [BindProperty]
        public Course course { get; set; }
        public EditModel(AppDbContext data)
        {
            this.data = data;
        }
        public async Task OnGet(int id)
        {
            course = await data.Course.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var courseFromDb = await data.Course.FindAsync(course.ID);
                courseFromDb.Name = course.Name;
                courseFromDb.Duration = course.Duration;
                courseFromDb.Courses = course.Courses;
                courseFromDb.degree = course.degree;


                await data.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }

    }

}

