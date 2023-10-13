using System.ComponentModel.DataAnnotations;
namespace AplikimiDigjital.Models
{
    public class Aplikimi
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string StudentID { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string NumriTelefonit { get; set; }
    }
}
