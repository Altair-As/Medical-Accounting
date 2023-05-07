using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationAuth.Data;
using WebApplicationAuth.Models;

namespace WebApplicationAuth.Pages.Administration.Patients
{
    public class CreateModel : PageModel
    {
        private readonly WebApplicationAuth.Data.ApplicationDbContext _context;

        public CreateModel(WebApplicationAuth.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MedicalCard MedicalCard { get; set; }
        

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid || _context.MedicalCards == null || MedicalCard == null)
            {
                return Page();
            }

            _context.MedicalCards.Add(MedicalCard);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
