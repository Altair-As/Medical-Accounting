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
    public class IndexModel : PageModel
    {
        private readonly WebApplicationAuth.Data.ApplicationDbContext _context;

        public IndexModel(WebApplicationAuth.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Medicine> Medicine { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Medicine != null)
            {
                Medicine = await _context.Medicine.ToListAsync();
            }
        }
    }
}
