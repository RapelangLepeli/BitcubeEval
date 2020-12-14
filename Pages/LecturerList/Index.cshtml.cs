using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Training_Facility.Model;

namespace Training_Facility.Pages.LecturerList
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext data;
        public IEnumerable<Lecturer> lecturers { get; set; }
        public IndexModel(AppDbContext data)
        {
            this.data = data;
        }
      
        public async Task OnGetAsync()
        {
            lecturers = await data.Lecturer.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var lecturer= await data.Lecturer.FindAsync(id);

            if(lecturer == null)
            {
                return NotFound();
            }
            data.Lecturer.Remove(lecturer);

            await data.SaveChangesAsync();
            return RedirectToPage("Index");
        }

    }
}
