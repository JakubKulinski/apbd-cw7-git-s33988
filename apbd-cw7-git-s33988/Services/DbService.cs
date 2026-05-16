using apbd_cw7_git_s33988.DTOs;
using apbd_cw7_git_s33988.Models;
using apbd_cw7_git_s33988.Data;
using apbd_cw7_git_s33988.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace apbd_cw7_git_s33988.Services;

public class DbService : IDbService
{
    private readonly AppDbContext _context;
    
    public DbService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<PcResponseDto>> GetAllAsync()
    {
        return await _context.PCs
            .Select(p => new PcResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Weight = p.Weight,
                Warranty =  p.Warranty,
                CreatedAt =  p.CreatedAt,
                Stock =  p.Stock
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<PcComponentResponseDto>> GetComponentsByPcIdAsync(int pcId)
    {
        var pcExists = await _context.PCs.AnyAsync(p => p.Id == pcId);
        if (!pcExists)
        {
            throw new NotFoundException($"PC with id {pcId} not found");
        }
        
        return await _context.PCComponents
            .Where(pc => pc.PCId == pcId)
            .Select(pc => new PcComponentResponseDto
            {
                ComponentCode = pc.ComponentCode,
                Name = pc.Component.Name,
                Description = pc.Component.Description,
                ComponentType =  pc.Component.ComponentType.Name,
                Manufacturer = pc.Component.ComponentManufacturer.FullName,
                Amount = pc.Amount
            })
            .ToListAsync();
    }

    public async Task<PcResponseDto> CreateAsync(CreatePcRequestDto dto)
    {
        var pc = new Pc
        {
            Name = dto.Name,
            Weight = dto.Weight,
            Warranty = dto.Warranty,
            CreatedAt = dto.CreatedAt,
            Stock = dto.Stock
        };
        
        _context.PCs.Add(pc);
        await _context.SaveChangesAsync();

        return new PcResponseDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }

    public async Task UpdateAsync(int id, UpdatePcRequestDto dto)
    {
        var pc = await _context.PCs.FirstOrDefaultAsync(p => p.Id == id);
        if (pc == null)
        {
            throw new NotFoundException($"PC with id {id} not found");
        }
        pc.Name = dto.Name;
        pc.Weight = dto.Weight;
        pc.Warranty = dto.Warranty;
        pc.CreatedAt = dto.CreatedAt;
        pc.Stock = dto.Stock;
        
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var pc = await _context.PCs.FirstOrDefaultAsync(p => p.Id == id);
        if (pc == null)
        {
            throw new NotFoundException($"PC with id {id} not found");
        }
        _context.PCs.Remove(pc);
        await _context.SaveChangesAsync();
    }
}