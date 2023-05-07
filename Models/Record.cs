using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace WebApplicationAuth.Models
{
    public class Record
    {
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "Date")]
        public DateTime AppointmentDate { get; set; } = DateTime.Today;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "Time")]
        public TimeSpan AppointmentTime { get; set; } = DateTime.Now.TimeOfDay;
        public string AppointmentType { get; set; } = "Appointment";
        public string Document { get; set; } = "Passport";
        public string Result { get; set; } = String.Empty;
        public string Complaints { get; set; } = String.Empty;
        public string Symptoms { get; set;} = String.Empty;
        public string Diagnosis { get; set; } = String.Empty;
        public MedicalCard ? MedicalCard { get; set; }
        public int MedicalCardId { get; set; }
        public Employer ? Employer { get; set; }
        public int EmployerId { get; set; }
        public List<Medicine> ? Medications { get; set; }

    }
}
