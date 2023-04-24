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

        public MedicalCardsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            cards = _context.MedicalCards.ToList();
        }
    }
}
