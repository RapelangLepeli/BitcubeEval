using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Training_Facility.Model;

namespace Training_Facility.Pages.DegreeList
{
    public class EditModel : PageModel
    {
        private AppDbContext data;

        [BindProperty]
        public Degree degree { get; set; }
        public EditModel(AppDbContext data)
        {
            this.data = data;
        }
        public async Task OnGet(int id)
        {
            degree = await data.Degree.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var degreeFromDB = await data.Degree.FindAsync(degree.ID);
                degreeFromDB.Name = degree.Name;
                degreeFromDB.Duration = degree.Duration;
                degreeFromDB.Courses = degree.Courses;
                degreeFromDB.lecturer = degree.lecturer;
               

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

