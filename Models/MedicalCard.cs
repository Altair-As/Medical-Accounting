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
        [MaxLength(14)]
        public string SNILS { get; set; } = string.Empty;
        [MaxLength(12)]
        public string Passport { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "Date")]
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; } = string.Empty;
        public float Weight { get; set; }
        public float Height { get; set; }
        public string? ImagePath { get; set; } = "~/images/notfound.jpg";
        public List<ChronicIllness> Illnesses { get; set; }
        public List<Record> Records { get; set; }

    }
}
