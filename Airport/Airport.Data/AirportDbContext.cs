using Airport.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Airport.Core.Interfaces;

namespace Airport.Data;

public class AirportDbContext : DbContext, IAirportDbContext
{
    public AirportDbContext(DbContextOptions<AirportDbContext> options)
        : base(options)
    {
    }

    public DbSet<AirportEntity> Airports { get; set; }

    public DbSet<PassengerEntity> Passengers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AirportEntity>(entity =>
        {
            entity.HasKey(a => a.Id);

            entity.Property(a => a.Code)
                .IsRequired()
                .HasMaxLength(3);

            entity.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<PassengerEntity>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Name).IsRequired();
            entity.Property(p => p.Surname).IsRequired();
            entity.Property(p => p.PassportNumber).IsRequired();

            entity.HasOne(p => p.Airport)
                .WithMany(a => a.Passengers)
                .HasForeignKey(p => p.AirportId)
                .OnDelete(DeleteBehavior.Restrict);
        });


        base.OnModelCreating(modelBuilder);
    }
}
