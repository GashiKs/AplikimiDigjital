using System.ComponentModel.DataAnnotations;
namespace AplikimiDigjital.Entities
{
    public class CommentEntity
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
