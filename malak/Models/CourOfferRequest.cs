namespace malak.Models
{
    public class CourOfferRequest
    {
        public Guid idCour { get; set; }
        public DateTime? startime { get; set; }
        public DateTime? endtime { get; set; }
        public double Price { get; set; }

        public bool IsOffred { get; set; }
    }
}
