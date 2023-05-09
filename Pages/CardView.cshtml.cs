using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using WebApplicationAuth.Data;
using WebApplicationAuth.Data.DTO;
using WebApplicationAuth.Data.Migrations;
using WebApplicationAuth.Models;

namespace WebApplicationAuth.Pages
{
    [Authorize]
    public class CardViewModel : PageModel
    {
        public int age;
        public List<Record>? patientsRecords;
        public List<ChronicIllness>? patientsIllneses;
        private readonly ApplicationDbContext _context;
        public MedicalCard medicalCard;

        [BindProperty(SupportsGet = true)]
        public int Id {  get; set; }

        public CardViewModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            medicalCard = _context.MedicalCards.FirstOrDefault(c => c.Id == Id);

            medicalCard.ImagePath = medicalCard.Insurance + ".jpg";

            patientsIllneses = _context.Entry(medicalCard)
                .Collection(p => p.Illnesses)
                .Query()
                .ToList();

            patientsRecords = _context.Entry(medicalCard)
                .Collection(p => p.Records)
                .Query()
                .ToList();

            patientsRecords.ForEach(p =>
            {
                p.Employer = _context.Employers.FirstOrDefault(c => c.Id == p.EmployerId);
                var medicines = _context.Records
                    .Where(r => r.Id == p.Id)
                    .SelectMany(r => r.Medications)
                    .ToList();
                p.Medications = medicines;
            });

            ViewData["Illnesses"] = new SelectList(_context.ChronicIllnesses, "Title", "Title");

            DateTime now = DateTime.Now;
            age = now.Year - medicalCard.DateOfBirth.Year;
            if (medicalCard.DateOfBirth.AddYears(age) > now)
            {
                age--;
            }
        }

        public IActionResult OnPostAddIllness(string illness)
        {
            
            if (illness != null)
            {
                ChronicIllness newIllness = _context.ChronicIllnesses.Where(c => c.Title == illness).FirstOrDefault();

                medicalCard = _context.MedicalCards.FirstOrDefault(c => c.Id == Id);

                patientsIllneses = _context.Entry(medicalCard)
                    .Collection(p => p.Illnesses)
                    .Query()
                    .ToList();

                if (newIllness != null)
                {
                    medicalCard.Illnesses.Add(newIllness);
                    _context.SaveChanges();
                }

            }
            OnGet();
            return Page();
        }

    }
}
