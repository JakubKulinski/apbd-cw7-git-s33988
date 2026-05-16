using apbd_cw7_git_s33988.DTOs;

namespace apbd_cw7_git_s33988.Services;

public interface IDbService
{
    Task<IEnumerable<PcResponseDto>> GetAllAsync();
    
    Task<IEnumerable<PcComponentResponseDto>> GetComponentsByPcIdAsync(int pcId);

    Task<PcResponseDto> CreateAsync(CreatePcRequestDto dto);
    
    Task UpdateAsync(int id, UpdatePcRequestDto dto);
    
    Task DeleteAsync(int id);
}