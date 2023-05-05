using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationAuth.Data;
using WebApplicationAuth.Models;

namespace WebApplicationAuth.Pages.Administration
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
        public ChronicIllness ChronicIllness { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ChronicIllnesses == null || ChronicIllness == null)
            {
                return Page();
            }

            _context.ChronicIllnesses.Add(ChronicIllness);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
