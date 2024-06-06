using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace malak.Entities
{
    public class Prof
    {
        [Key]
        public Guid idProf { get; set; }

        [Required]
        [MaxLength(100)]
        public string? NomProf { get; set; }
        [Required]
        [MaxLength(100)]
        public string? prenom { get; set; }
        [Required]
        [MaxLength(100)]
        public string? adresse { get; set; }
        public string? email { get; set; }

        public string? tel { get; set; }

        [ForeignKey("idCentre")]
        public Centre? Centre { get; set; }
        public Guid idCentre { get; set; }
    }
}
