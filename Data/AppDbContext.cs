using DeliveryApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DeliveryApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext>options) : base(options){}

    /// <summary>
    /// Таблица в базе данных
    /// </summary>
    public DbSet<OrderRecord> Orders {get; set;} = null!;

    //Настройка схемы
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<OrderRecord>( entity => 
           { 
            entity.Property(e => e.OriginCity)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.OriginAddress)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(e => e.DestinationCity)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.DestinationAddress)
                .IsRequired()
                .HasMaxLength(200);
            
            entity.Property(e => e.Weight)
                .IsRequired();
            }
        );
    }
}