using System.ComponentModel.DataAnnotations;

namespace malak.Entities
{
    public class Centre
    {
        [Key]
        public Guid idCentre { get; set; }
        [Required]
        [MaxLength(100)]
        public string? NomCentre { get; set; }
        [Required]
        [MaxLength(100)]

        public string? adresse { get; set; }
        public string? email { get; set; }

        public string? tel { get; set; }
    }
}
