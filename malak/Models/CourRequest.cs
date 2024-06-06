namespace malak.Models
{
    public class CourRequest
    {
        public Guid idCour { get; set; }
        public string? nomCour { get; set; }
        public string? Description { get; set; }
        public DateTime? startime { get; set; }
        public DateTime? endtime { get; set; }
        public double? Price { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsOffred { get; set; }
        public Guid idProf { get; set; }
    }
}
