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
        public DateTime AppointmentDade { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "Time")]
        public TimeSpan AppointmentTime { get; set; }
        public string AppointmentType { get; set; } = "Outpatient appointment";
        public string Document { get; set; } = "Passport";
        public string Result { get; set; } = String.Empty;
        public string Complaints { get; set; } = String.Empty;
        public string Symptoms { get; set;} = String.Empty;
        public MedicalCard MedicalCardNumber { get; set; }
        public Employer MD { get; set; }

    }
}
