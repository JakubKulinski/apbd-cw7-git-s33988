using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apbd_cw7_git_s33988.Models;

[Table("PCs")]
public class Pc
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } =  string.Empty;
    
    [Column(TypeName = "float")]
    public double Weight { get; set; }
    
    public int Warranty { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public int Stock { get; set; }

    public ICollection<PcComponent> PcComponents { get; set; } = [];
}