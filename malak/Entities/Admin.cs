using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace malak.Entities
{
    public class Admin
    {
        [Key]
        public Guid idAdmin { get; set; }

        [Required]
        [MaxLength(100)]
        public string? nomAdmin { get; set; }
        [Required]
        [MaxLength(100)]
        public string? prenom { get; set; }
        [Required]
        [MaxLength(100)]
        public string? adresse { get; set; }
        public string? email { get; set; }

        public string? tel { get; set; }
        
    }
}
