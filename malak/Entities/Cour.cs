using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace malak.Entities
{
    public class Cour
    {
        [Key]
        public Guid idCour { get; set; }

        [Required]
        [MaxLength(100)]
        public string? NomCour { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Description { get; set; }
        [Required]
        [MaxLength(100)]
        public DateTime? StarTime { get; set; }
        public DateTime? EndTime { get; set; }
        public double? Price { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsOffred { get; set; }
        [ForeignKey("idProf")]
        public Prof? Prof { get; set; }
        public Guid idProf { get; set; }
    }
}
