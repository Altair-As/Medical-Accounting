using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationAuth.Data;
using WebApplicationAuth.Models;

namespace WebApplicationAuth.Pages.Medications
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplicationAuth.Data.ApplicationDbContext _context;

        public DeleteModel(WebApplicationAuth.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Medicine Medicine { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Medicine == null)
            {
                return NotFound();
            }

            var medicine = await _context.Medicine.FirstOrDefaultAsync(m => m.Id == id);

            if (medicine == null)
            {
                return NotFound();
            }
            else 
            {
                Medicine = medicine;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Medicine == null)
            {
                return NotFound();
            }
            var medicine = await _context.Medicine.FindAsync(id);

            if (medicine != null)
            {
                Medicine = medicine;
                _context.Medicine.Remove(Medicine);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
