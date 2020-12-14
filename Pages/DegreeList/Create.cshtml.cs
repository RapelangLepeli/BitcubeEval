using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Training_Facility.Model;

namespace Training_Facility.Pages.DegreeList
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext data;
        [BindProperty]
        public Degree degree { get; set; }
        public CreateModel(AppDbContext data)
        {
            this.data = data;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await data.Degree.AddAsync(degree);
                await data.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }

}

