// Подключение модулей

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationAuth.Data;
using WebApplicationAuth.Models;

namespace WebApplicationAuth.Pages.Administration.Appointments
{
    public class CreateModel : PageModel
    {
        // Внедрение зависимостей
        private readonly WebApplicationAuth.Data.ApplicationDbContext _context;

        public CreateModel(WebApplicationAuth.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        // Обработка загрузки страницы
        public IActionResult OnGet()
        {
        ViewData["EmployerId"] = new SelectList(_context.Employers, "Id", "Id");
        ViewData["MedicalCardId"] = new SelectList(_context.MedicalCards, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Record Record { get; set; } = default!;

        // Обработка создания записи
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Records == null || Record == null)
            {
                return Page();
            }

            _context.Records.Add(Record);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
