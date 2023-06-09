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

namespace WebApplicationAuth.Pages.Administration.Patients
{
    public class DetailsModel : PageModel
    {
        // Внедрение зависимостей
        private readonly WebApplicationAuth.Data.ApplicationDbContext _context;

        public DetailsModel(WebApplicationAuth.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public MedicalCard MedicalCard { get; set; } = default!;

        // Обработка загрузки страницы
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MedicalCards == null)
            {
                return NotFound();
            }

            var medicalcard = await _context.MedicalCards.FirstOrDefaultAsync(m => m.Id == id);
            if (medicalcard == null)
            {
                return NotFound();
            }
            else 
            {
                MedicalCard = medicalcard;
            }
            return Page();
        }
    }
}
