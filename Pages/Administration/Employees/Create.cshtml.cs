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

namespace WebApplicationAuth.Pages.Administration.Employees
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
            return Page();
        }

        [BindProperty]
        public Employer Employer { get; set; } = default!;

        // Обработка создания записи
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Employers == null || Employer == null)
            {
                return Page();
            }

            _context.Employers.Add(Employer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
