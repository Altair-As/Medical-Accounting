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

namespace WebApplicationAuth.Pages.Administration
{
    public class DeleteModel : PageModel
    {
        // Внедрение зависимостей
        private readonly WebApplicationAuth.Data.ApplicationDbContext _context;

        public DeleteModel(WebApplicationAuth.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ChronicIllness ChronicIllness { get; set; } = default!;

        // Обработка загрузки страницы
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

        // Обработка удаления записи
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ChronicIllnesses == null)
            {
                return NotFound();
            }
            var chronicillness = await _context.ChronicIllnesses.FindAsync(id);

            if (chronicillness != null)
            {
                ChronicIllness = chronicillness;
                _context.ChronicIllnesses.Remove(ChronicIllness);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
