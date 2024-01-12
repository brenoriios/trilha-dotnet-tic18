using Microsoft.EntityFrameworkCore;
using Techmed.Domain.Entities;
namespace Techmed.Infrastructure.TechmedDbContext;
public class TechmedDbContext : DbContext
{
    public TechmedDbContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var connectionString = "server=localhost;user=dotnet;password=tic2023;database=techmed";
        var serverVersion = ServerVersion.AutoDetect(connectionString);
        optionsBuilder.UseMySql(connectionString, serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Doctor>().ToTable("doctors").HasKey(d => d.Id);
        modelBuilder.Entity<Patient>().ToTable("patients").HasKey(p => p.Id);
        modelBuilder.Entity<Appointment>().ToTable("appointments").HasKey(a => a.Id);
        modelBuilder.Entity<Exam>().ToTable("exams").HasKey(e => e.Id);
    }
}
