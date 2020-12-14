using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Training_Facility.Model;

namespace Training_Facility.Pages.DegreeList
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext data;

        public IndexModel(AppDbContext data)
        {
            this.data = data;
        }
        public IEnumerable<Degree> Degrees { get; set; }
        public async Task OnGetAsync()
        {
            Degrees = await data.Degree.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var degree = await data.Degree.FindAsync(id);

            if (degree == null)
            {
                return NotFound();
            }
            data.Degree.Remove(degree);

            await data.SaveChangesAsync();
            return RedirectToPage("Index");
        }

    }

}

