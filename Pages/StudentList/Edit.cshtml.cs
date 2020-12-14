using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Training_Facility.Model;

namespace Training_Facility.Pages.StudentList
{
    public class EditModel : PageModel
    {
        private AppDbContext data;

        [BindProperty]
        public Student student { get; set; }
        public EditModel(AppDbContext data)
        {
            this.data = data;
        }
        public async Task OnGet(int id)
        {
            student = await data.Student.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var studentfromDB = await data.Student.FindAsync(student.ID);
                studentfromDB.ForeNames = student.ForeNames;
                studentfromDB.Surname = student.Surname;
                studentfromDB.DateOfBirth = student.DateOfBirth;
                studentfromDB.EmailAddress = student.EmailAddress;
                studentfromDB.degree = student.degree;
                
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
