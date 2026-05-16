using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apbd_cw7_git_s33988.Models;

[PrimaryKey(nameof(PCId), nameof(ComponentCode))]
[Table("PCComponents")]
public class PcComponent
{
    public int PCId { get; set; }
    
    [ForeignKey(nameof(PCId))]
    public Pc Pc { get; set; } = null!;
    
    [MaxLength(10)]
    [Column(TypeName = "char(10)")]
    public string ComponentCode { get; set; } =  String.Empty;
    
    [ForeignKey(nameof(ComponentCode))]
    public Component Component { get; set; } = null!;
    
    public int Amount { get; set; }
}