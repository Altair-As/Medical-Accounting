// Подключение модулей

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

namespace WebApplicationAuth.Pages.Administration.Patients
{
    public class EditModel : PageModel
    {
        // Внедрение зависимостей
        private readonly WebApplicationAuth.Data.ApplicationDbContext _context;

        public EditModel(WebApplicationAuth.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MedicalCard MedicalCard { get; set; } = default!;

        // Обработка загрузки страницы
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MedicalCards == null)
            {
                return NotFound();
            }

            var medicalcard =  await _context.MedicalCards.FirstOrDefaultAsync(m => m.Id == id);
            if (medicalcard == null)
            {
                return NotFound();
            }
            MedicalCard = medicalcard;
            return Page();
        }

        // Обработка изменения записи
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MedicalCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalCardExists(MedicalCard.Id))
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

        private bool MedicalCardExists(int id)
        {
          return (_context.MedicalCards?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
