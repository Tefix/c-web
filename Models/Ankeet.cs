using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Ankeet
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Pyha")]
        public int PyhaId { get; set; }
        
        [Required]
        [StringLength(100)]
        [Display(Name = "Nimi")]
        public string Nimi { get; set; }
        
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [StringLength(500)]
        [Display(Name = "Kommentaar")]
        public string Kommentaar { get; set; }
    }
}