using System.ComponentModel.DataAnnotations;

namespace WebApplicationAuth.Models
{
    public class ChronicIllness
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        [MaxLength(6)]
        public string Code { get; set; } = "Y35RJ1";
        public List<MedicalCard> MedicalCards { get; set; }
    }
}
