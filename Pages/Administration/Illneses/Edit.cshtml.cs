using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationAuth.Data;
using WebApplicationAuth.Models;

namespace WebApplicationAuth.Pages.Administration
{
    public class EditModel : PageModel
    {
        private readonly WebApplicationAuth.Data.ApplicationDbContext _context;

        public EditModel(WebApplicationAuth.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ChronicIllness ChronicIllness { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ChronicIllnesses == null)
            {
                return NotFound();
            }

            var chronicillness =  await _context.ChronicIllnesses.FirstOrDefaultAsync(m => m.Id == id);
            if (chronicillness == null)
            {
                return NotFound();
            }
            ChronicIllness = chronicillness;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ChronicIllness).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChronicIllnessExists(ChronicIllness.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ChronicIllnessExists(int id)
        {
          return (_context.ChronicIllnesses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
