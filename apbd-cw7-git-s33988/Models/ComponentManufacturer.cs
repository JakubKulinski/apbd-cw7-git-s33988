using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apbd_cw7_git_s33988.Models;

[Table("ComponentManufacturers")]
public class ComponentManufacturer
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string Abbreviation { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(300)]
    public string FullName { get; set; } = string.Empty;
    
    public DateOnly FoundationDate { get; set; }
    
    public ICollection<Component> Components { get; set; } = [];
}