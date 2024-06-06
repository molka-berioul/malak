namespace malak.Models
{
    public class CentreRequest
    {
        public Guid idCentre { get; set; }
        public string? nomCentre { get; set; }
        public string? adresse { get; set; }
        public string? email { get; set; }

        public string? tel { get; set; }
    }
}
