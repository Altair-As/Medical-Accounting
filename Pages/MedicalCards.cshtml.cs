// Подключение модулей

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationAuth.Data;
using WebApplicationAuth.Models;

namespace WebApplicationAuth.Pages
{

    [Authorize]
    public class MedicalCardsModel : PageModel
    {
        // Внедрение зависимостей
        private readonly ApplicationDbContext _context;
        public List<MedicalCard> cards;

        [BindProperty]
        public string SearchText { get; set; }

        public MedicalCardsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Обработка поиска записей
        public IActionResult OnPost()
        {
            string searchText = SearchText;
            if (searchText == null)
            {
                OnGet();
                return Page();
            }
            cards = _context.MedicalCards
                .Where(m => m.FIO.Contains(searchText))
                .ToList();
            return Page();
        }

        // Обработка загрузки страницы
        public void OnGet()
        {
            cards = _context.MedicalCards.ToList();
        }

    }
}
