// Подключение модулей

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationAuth.Data;
using WebApplicationAuth.Models;

namespace WebApplicationAuth.Pages.Administration.Appointments
{
    public class DetailsModel : PageModel
    {
        // Внедрение зависимостей
        private readonly WebApplicationAuth.Data.ApplicationDbContext _context;

        public DetailsModel(WebApplicationAuth.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Record Record { get; set; } = default!;

        // Обработка загрузки страницы
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Records == null)
            {
                return NotFound();
            }

            var record = await _context.Records.FirstOrDefaultAsync(m => m.Id == id);
            if (record == null)
            {
                return NotFound();
            }
            else 
            {
                Record = record;
            }

            if (_context.Records != null)
            {
                Record.Employer = _context.Employers.FirstOrDefault(e => e.Id == Record.EmployerId);
                Record.MedicalCard = _context.MedicalCards.FirstOrDefault(e => e.Id == Record.MedicalCardId);
            }

            return Page();
        }
    }
}
