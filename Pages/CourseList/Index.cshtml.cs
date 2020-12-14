using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Training_Facility.Model;

namespace Training_Facility.Pages.CourseList
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext data;

        public IndexModel(AppDbContext data)
        {
            this.data = data;
        }
        public IEnumerable<Course> Courses { get; set; }
        public async Task OnGetAsync()
        {
            Courses = await data.Course.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var course = await data.Course.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }
            data.Course.Remove(course);

            await data.SaveChangesAsync();
            return RedirectToPage("Index");
        }

    }

}
