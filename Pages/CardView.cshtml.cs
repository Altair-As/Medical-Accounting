using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationAuth.Data;
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

        [BindProperty]
        public MedicalCard medicalCard { get; set; }

        public CardViewModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet(int Id)
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



            DateTime now = DateTime.Now;
            age = now.Year - medicalCard.DateOfBirth.Year;
            if (medicalCard.DateOfBirth.AddYears(age) > now)
            {
                age--;
            }
        }
    }
}
