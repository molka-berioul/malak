namespace malak.Models
{
    public class AdminRequest
    {
        public Guid idAdmin { get; set; }
        public string? nomAdmin { get; set; }
        public string? prenom { get; set; }
        public string? adresse { get; set; }
        public string? email { get; set; }

        public string? tel { get; set; }
    }
}
