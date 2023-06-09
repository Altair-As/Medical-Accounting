namespace WebApplicationAuth.Models
{
    // Объявление модели лекарства
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; }
        public List<Record> ? Records { get; set; }
    }
}
