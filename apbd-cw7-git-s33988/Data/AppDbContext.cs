using apbd_cw7_git_s33988.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd_cw7_git_s33988.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Pc> PCs { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<PcComponent> PCComponents { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<ComponentType>().HasData(
            new ComponentType { Id = 1, Abbreviation = "CPU", Name = "Central Processing Unit" },
            new ComponentType { Id = 2, Abbreviation = "GPU", Name = "Graphics Processing Unit" },
            new ComponentType { Id = 3, Abbreviation = "RAM", Name = "Random Access Memory" },
            new ComponentType { Id = 4, Abbreviation = "SSD", Name = "Solid State Drive" }
        );
        
        modelBuilder.Entity<ComponentManufacturer>().HasData(
            new ComponentManufacturer { Id = 1, Abbreviation = "INTEL", FullName = "Intel Corporation", FoundationDate = new DateOnly(1968, 7, 18) },
            new ComponentManufacturer { Id = 2, Abbreviation = "NVIDIA", FullName = "NVIDIA Corporation", FoundationDate = new DateOnly(1993, 4, 5) },
            new ComponentManufacturer { Id = 3, Abbreviation = "SAMSUNG", FullName = "Samsung Electronics Co., Ltd.", FoundationDate = new DateOnly(1969, 1, 13)
            }
        );
        
        modelBuilder.Entity<Component>().HasData(
            new Component { Code = "I9-14900K ", Name = "Intel Core i9-14900K", Description = "High-end desktop processor, 24 cores, 6.0 GHz boost", ComponentManufacturersId = 1, ComponentTypesId = 1 },
            new Component { Code = "RTX4090   ", Name = "NVIDIA GeForce RTX 4090", Description = "Flagship Ada Lovelace GPU, 24 GB GDDR6X", ComponentManufacturersId = 2, ComponentTypesId = 2 },
            new Component { Code = "DDR5-32GB ", Name = "Samsung 32 GB DDR5-5600", Description = "High-speed DDR5 memory module", ComponentManufacturersId = 3, ComponentTypesId = 3 },
            new Component { Code = "990PRO2TB ", Name = "Samsung 990 Pro 2 TB NVMe", Description = "Gen4 NVMe SSD, 7450 MB/s read", ComponentManufacturersId = 3, ComponentTypesId = 4 },
            new Component { Code = "I5-13500  ", Name = "Intel Core i5-13500", Description = "Mid-range desktop processor, 14 cores", ComponentManufacturersId = 1, ComponentTypesId = 1 }
        );
        
        modelBuilder.Entity<Pc>().HasData(
            new Pc { Id = 1, Name = "Gaming Beast X", Weight = 12.5, Warranty = 36, CreatedAt = new DateTime(2026, 5, 8, 9, 0, 0), Stock = 5 },
            new Pc { Id = 2, Name = "Office Mini Pro", Weight = 4.2, Warranty = 24, CreatedAt = new DateTime(2026, 4, 15, 13, 30, 0), Stock = 12 },
            new Pc { Id = 3, Name = "Workstation Ultra", Weight = 18.0, Warranty = 48, CreatedAt = new DateTime(2026, 3, 1, 10, 0, 0), Stock = 3 }
        );
        
        modelBuilder.Entity<PcComponent>().HasData(
            new PcComponent { PCId = 1, ComponentCode = "I9-14900K ", Amount = 1 },
            new PcComponent { PCId = 1, ComponentCode = "RTX4090   ", Amount = 1 },
            new PcComponent { PCId = 1, ComponentCode = "DDR5-32GB ", Amount = 2 },
            new PcComponent { PCId = 1, ComponentCode = "990PRO2TB ", Amount = 1 },
            new PcComponent { PCId = 2, ComponentCode = "I5-13500  ", Amount = 1 },
            new PcComponent { PCId = 2, ComponentCode = "DDR5-32GB ", Amount = 1 },
            new PcComponent { PCId = 3, ComponentCode = "I9-14900K ", Amount = 2 },
            new PcComponent { PCId = 3, ComponentCode = "RTX4090   ", Amount = 2 },
            new PcComponent { PCId = 3, ComponentCode = "DDR5-32GB ", Amount = 4 },
            new PcComponent { PCId = 3, ComponentCode = "990PRO2TB ", Amount = 2 }
        );
    }
}