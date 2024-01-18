using Microsoft.EntityFrameworkCore;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Infrastructure.Context;
public class ResTIConnectDbContext : DbContext
{
    public DbSet<Log> logs{ get; set; }

    public ResTIConnectDbContext(){}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var connectionString = "server=localhost;user=dotnet;password=tic2023;database=resticonnect";
        var databaseVersion = ServerVersion.AutoDetect(connectionString);
        optionsBuilder.UseMySql(connectionString, databaseVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Log>().ToTable("logs").HasKey(log => log.LogId);
    }
}
