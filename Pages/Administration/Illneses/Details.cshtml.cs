using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationAuth.Data;
using WebApplicationAuth.Models;

namespace WebApplicationAuth.Pages.Administration
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplicationAuth.Data.ApplicationDbContext _context;

        public DetailsModel(WebApplicationAuth.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public ChronicIllness ChronicIllness { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ChronicIllnesses == null)
            {
                return NotFound();
            }

            var chronicillness = await _context.ChronicIllnesses.FirstOrDefaultAsync(m => m.Id == id);
            if (chronicillness == null)
            {
                return NotFound();
            }
            else 
            {
                ChronicIllness = chronicillness;
            }
            return Page();
        }
    }
}
