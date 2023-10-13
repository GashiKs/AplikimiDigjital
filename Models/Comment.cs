using System.ComponentModel.DataAnnotations;
namespace AplikimiDigjital.Models
{
    public class Comment
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
