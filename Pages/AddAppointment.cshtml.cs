using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationAuth.Data;
using WebApplicationAuth.Data.DTO;
using WebApplicationAuth.Models;

namespace WebApplicationAuth.Pages
{
    public class AddAppointmentModel : PageModel
    {

        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationIdentityUser> _signInManager;

        public MedicalCard? card;
        public Employer? employer;

        [BindProperty]
        public Record Record { get; set; } = default!;

        public AddAppointmentModel(ApplicationDbContext context,
            SignInManager<ApplicationIdentityUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        public void OnGet(int Id)
        {
            card = _context.MedicalCards.Where(p => p.Id == Id).FirstOrDefault();
            employer = _context.Employers.Where(e => e.Email == User.Identity.Name).FirstOrDefault();
        }

        public async Task<IActionResult> OnPostAsync() 
        {
            if (!ModelState.IsValid || _context.Records == null || Record == null)
            {
                return Page();
            }

            _context.Records.Add(Record);
            await _context.SaveChangesAsync();

            MedicalCardIdDTO idDTO = new MedicalCardIdDTO()
            { Id = Record.MedicalCardId };

            return RedirectToPage("/CardView", idDTO);
        }
    }
}
