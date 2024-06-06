using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace malak.Entities
{
    public class Student
    {
        [Key]
        public Guid idStudent { get; set; }
        [Required]
        [MaxLength(100)]
        public string? NomStudent { get; set; }
        [Required]
        [MaxLength(100)]
        public string? prenom { get; set; }
        [Required]
        [MaxLength(100)]
        public string? adresse { get; set; }
        public string? email { get; set; }

        public string? tel { get; set; }
        [ForeignKey("idCour")]
        public Cour? Cours { get; set; }
        public Guid idCour { get; set; }
    }
}
