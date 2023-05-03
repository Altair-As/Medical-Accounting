using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationAuth.Data;
using WebApplicationAuth.Models;

namespace WebApplicationAuth.Pages
{
    public class MedicalCardsModel : PageModel
    {

        private readonly ApplicationDbContext _context;
        public List<MedicalCard> cards;

        [BindProperty]
        public string SearchText { get; set; }

        public MedicalCardsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnPost()
        {
            string searchText = SearchText;
            cards = _context.MedicalCards
                .Where(m => m.FIO.Contains(searchText))
                .ToList();
            return Page();
        }

        public void OnGet()
        {
            cards = _context.MedicalCards.ToList();
        }

    }
}
