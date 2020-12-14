using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Training_Facility.Model;

namespace Training_Facility.Pages.StudentList
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext data;

        public IndexModel(AppDbContext data)
        {
            this.data = data;
        }
        public IEnumerable<Student> Students { get; set; }
        public async Task OnGetAsync()
        {
            Students = await data.Student.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var student = await data.Student.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }
            data.Student.Remove(student);

            await data.SaveChangesAsync();
            return RedirectToPage("Index");
        }

    }

}
