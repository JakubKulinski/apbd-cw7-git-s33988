namespace apbd_cw7_git_s33988.DTOs;

public class PcComponentResponseDto
{
    public string ComponentCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ComponentType { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public int Amount { get; set; }
}