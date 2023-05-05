using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationAuth.Data;
using WebApplicationAuth.Models;

namespace WebApplicationAuth.Pages.Administration.Patients
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplicationAuth.Data.ApplicationDbContext _context;

        public DeleteModel(WebApplicationAuth.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public MedicalCard MedicalCard { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MedicalCards == null)
            {
                return NotFound();
            }

            var medicalcard = await _context.MedicalCards.FirstOrDefaultAsync(m => m.Id == id);

            if (medicalcard == null)
            {
                return NotFound();
            }
            else 
            {
                MedicalCard = medicalcard;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.MedicalCards == null)
            {
                return NotFound();
            }
            var medicalcard = await _context.MedicalCards.FindAsync(id);

            if (medicalcard != null)
            {
                MedicalCard = medicalcard;
                _context.MedicalCards.Remove(MedicalCard);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
