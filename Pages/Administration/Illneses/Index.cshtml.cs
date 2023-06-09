// Подключение модулей

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

namespace WebApplicationAuth.Pages.Administration
{
    // Настройка доступа
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        // Внедрение зависимостей
        private readonly WebApplicationAuth.Data.ApplicationDbContext _context;

        public IndexModel(WebApplicationAuth.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ChronicIllness> ChronicIllness { get;set; } = default!;

        // Обработка загрузки страницы
        public async Task OnGetAsync()
        {
            if (_context.ChronicIllnesses != null)
            {
                ChronicIllness = await _context.ChronicIllnesses.ToListAsync();
            }
        }
    }
}
