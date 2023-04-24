using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace WebApplicationAuth.Models
{
    public class MedicalCard
    {
        public int Id { get; set; }
        public string FIO { get; set; } = "John Doe";
        [Required]
        [MaxLength(16)]
        public string Insurance { get; set; } = string.Empty;
        [MaxLength(11)]
        public string SNILS { get; set; } = string.Empty;
        [MaxLength(10)]
        public string Passport { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "Date")]
        public DateTime DateOfBirth { get; set; }
        public string Adress { get; set; } = string.Empty;
        public float Weight { get; set; }
        public float Height { get; set; }
        public List<ChronicIllness> Illnesses { get; set; }

    }
}
