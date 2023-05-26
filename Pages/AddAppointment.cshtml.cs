using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.RegularExpressions;
using WebApplicationAuth.Data;
using WebApplicationAuth.Data.DTO;
using WebApplicationAuth.Exceptions;
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

        public async Task<IActionResult> OnPostAsync(string Prescription) 
        {
            if (!ModelState.IsValid || _context.Records == null || Record == null)
            {
                return Page();
            }

            if (Prescription != null)
            {
                string[] MedicationsArray = Prescription.Split(new[] { ' ', '\t', '\n', '\r', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

                List<string> MedList = new List<string>();
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                foreach (string word in MedicationsArray)
                {
                    string cleanedWord = Regex.Replace(word, @"[^a-zA-Z0-9]+", "");
                    string capitalizedWord = textInfo.ToTitleCase(cleanedWord);
                    MedList.Add(capitalizedWord);
                }

                List<Medicine> Medications = new List<Medicine>();

                foreach (string drug in MedList)
                {
                    var drugOblect = _context.Medicine.Where(m => m.Name == drug).FirstOrDefault();
                    if (drugOblect != null)
                    {
                        Medications.Add(drugOblect);
                    }
                }

                Record.Medications = Medications;

            }
            else
            {
                //TODO handle null prescription
                throw new MyValidationException("Presctiption is null");
            }

            _context.Records.Add(Record);
            await _context.SaveChangesAsync();

            MedicalCardIdDTO idDTO = new MedicalCardIdDTO()
            { Id = Record.MedicalCardId };

            return RedirectToPage("/CardView", idDTO);
        }
    }
}
