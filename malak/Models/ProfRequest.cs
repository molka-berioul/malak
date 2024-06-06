namespace malak.Models
{
    public class ProfRequest
    {
        public Guid idProf { get; set; }
        public string? nomProf { get; set; }
        public string? prenom { get; set; }
        public string adresse { get; set; }
        public string? email { get; set; }

        public string? tel { get; set; }
        public Guid idCentre { get; set; }
    }
}
