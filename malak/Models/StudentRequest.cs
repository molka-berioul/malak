namespace malak.Models
{
    public class StudentRequest
    {
        public Guid idStudent { get; set; }
        public string? nomStudent { get; set; }
        public string? prenom { get; set; }
        public string? adresse { get; set; }
        public string? email { get; set; }

        public string? tel { get; set; }
        public Guid idCour { get; set; }
    }
}
