// Подключение модулей

using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.FileProviders;
using WebApplicationAuth.Data;
using WebApplicationAuth.Data.Migrations;
using WebApplicationAuth.Models;
using System.IO;
using WebApplicationAuth.Data.Classes;

namespace WebApplicationAuth.Pages
{ 

    [Authorize]
    public class CardViewModel : PageModel
    {
        // Внедрение зависимостей
        public int age;
        public List<Record>? patientsRecords;
        public List<ChronicIllness>? patientsIllneses;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly SignInManager<ApplicationIdentityUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public MedicalCard medicalCard;

        [BindProperty(SupportsGet = true)]
        public int Id {  get; set; }

        [BindProperty]
        public int recordId { get; set; }

        public CardViewModel(ApplicationDbContext context, 
            IWebHostEnvironment webHostEnvironment, 
            SignInManager<ApplicationIdentityUser> signInManager)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _signInManager = signInManager;
        }

        // Обработка загрузки страницы
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

        // Обработка добавления заболевания
        public IActionResult OnPostAddIllness(string illness)
        {
            
            if (illness != null)
            {
                ChronicIllness newIllness = _context.ChronicIllnesses
                    .Where(c => c.Title == illness).FirstOrDefault();

                medicalCard = _context.MedicalCards
                    .FirstOrDefault(c => c.Id == Id);

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

        // Обработка генерации документа
        public IActionResult OnPostGenerateDocument()
        {

            OnGet();

            Record record = _context.Records.Where(r => r.Id == recordId).FirstOrDefault();

            var medicines = _context.Records
                    .Where(r => r.Id == record.Id)
                    .SelectMany(r => r.Medications)
                    .ToList();

            record.Medications = medicines;

            string medicine = "";

            foreach (var m in record.Medications)
            {
                if (m != record.Medications.Last())
                {
                    medicine += m.Name + ", ";
                }
                else
                {
                    medicine += m.Name + ".";
                }
            }
                        
            if (medicine == "")
            {
                medicine = "none.";
            }

            Employer employer = _context.Employers.Where(e => e.Email == User.Identity.Name).FirstOrDefault();

            string sourceFilePath = _webHostEnvironment.WebRootPath + "/templates/Справка.docx";
            string destinationFilePath = _webHostEnvironment.WebRootPath + "/documents/doc.docx";

            DocxFileCopier docxFileCopier = new DocxFileCopier();
            docxFileCopier.CopyDocxFile(sourceFilePath, destinationFilePath);

            // Path to the Word document template
            string templatePath = _webHostEnvironment.WebRootPath + "/documents/doc.docx";

            // Load the template
            using (WordprocessingDocument doc = WordprocessingDocument.Open(templatePath, true))
            {
                // Access the main document part
                MainDocumentPart mainPart = doc.MainDocumentPart;

                // Find and replace placeholders in the document
                string placeholder1 = "[Patient's Full Name]";
                string replacement1 = medicalCard.FIO;
                ReplaceText(mainPart, placeholder1, replacement1);

                string placeholder2 = "[Patient's Date of Birth]";
                string replacement2 = medicalCard.DateOfBirth.ToString();
                ReplaceText(mainPart, placeholder2, replacement2);

                string placeholder3 = "[Doctor's Full Name]";
                string replacement3 = employer.FIO;
                ReplaceText(mainPart, placeholder3, replacement3);

                string placeholder4 = "[Diagnosis]";
                string replacement4 = record.Diagnosis;
                ReplaceText(mainPart, placeholder4, replacement4);

                string placeholder5 = "[Symptoms]";
                string replacement5 = record.Symptoms;
                ReplaceText(mainPart, placeholder5, replacement5);

                string placeholder6 = "[Diagnosis]";
                string replacement6 = record.Diagnosis;
                ReplaceText(mainPart, placeholder6, replacement6);

                string placeholder7 = "[Medicine]";
                string replacement7 = medicine;
                ReplaceText(mainPart, placeholder7, replacement7);

                string placeholder8 = "[Doctor's Designation]";
                string replacement8 = employer.Department;
                ReplaceText(mainPart, placeholder8, replacement8);

                string placeholder9 = "[Date]";
                string replacement9 = record.AppointmentDate.ToString("dd-MMMM-yyyy");
                ReplaceText(mainPart, placeholder9, replacement9);

                // Save the modified document
                mainPart.Document.Save();
            }

            string generatedDocumentPath = _webHostEnvironment.WebRootPath + "/documents/doc.docx";

            return PhysicalFile(generatedDocumentPath, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "generated_document.docx");
        }

        // Обработка документа
        private static void ReplaceText(MainDocumentPart mainPart, string placeholder, string replacement)
        {
            foreach (var text in mainPart.Document.Descendants<Text>())
            {
                if (text.Text.Contains(placeholder))
                {
                    text.Text = text.Text.Replace(placeholder, replacement);
                }
            }
        }

    }

}
