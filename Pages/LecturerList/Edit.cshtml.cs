using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Training_Facility.Model;

namespace Training_Facility.Pages.LecturerList
{
    public class EditModel : PageModel
    {
        private AppDbContext data;

        [BindProperty]
        public Lecturer lecturer { get; set; }
        public EditModel(AppDbContext data)
        {
            this.data = data;
        }
        public async Task OnGet(int id)
        {
            lecturer = await data.Lecturer.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var lecturerfromDB = await data.Lecturer.FindAsync(lecturer.ID);
                lecturerfromDB.ForeNames = lecturer.ForeNames;
                lecturerfromDB.Surname = lecturer.Surname;
                lecturerfromDB.DateOfBirth = lecturer.DateOfBirth;
                lecturerfromDB.EmailAddress = lecturer.EmailAddress;
                lecturerfromDB.degrees = lecturer.degrees;
                lecturerfromDB.courses = lecturer.courses;

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
