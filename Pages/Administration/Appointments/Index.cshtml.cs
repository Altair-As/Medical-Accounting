using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationAuth.Data;
using WebApplicationAuth.Models;

namespace WebApplicationAuth.Pages.Administration.Appointments
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly WebApplicationAuth.Data.ApplicationDbContext _context;

        public IndexModel(WebApplicationAuth.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Record> Record { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Records != null)
            {
                Record = await _context.Records
                    .Include(e => e.Employer).ToListAsync();
                Record = await _context.Records
                    .Include(e => e.MedicalCard).ToListAsync();
            }
        }
    }
}
