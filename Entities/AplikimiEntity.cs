using System.ComponentModel.DataAnnotations;
namespace AplikimiDigjital.Entities;

public class AplikimiEntity
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