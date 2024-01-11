using Microsoft.EntityFrameworkCore;

namespace Techmed.Model;
public class TechmedContext : DbContext {
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Exam> Exams { get; set; }

    public TechmedContext(){}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        base.OnConfiguring(optionsBuilder);
        var connectionString = "server=localhost;user=dotnet;password=tic2023;database=techmed";
        var serverVersion = ServerVersion.AutoDetect(connectionString);
        optionsBuilder.UseMySql(connectionString, serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Doctor>().ToTable("doctors").HasKey(d => d.Id);
        modelBuilder.Entity<Patient>().ToTable("patients").HasKey(p => p.Id);
        modelBuilder.Entity<Appointment>().ToTable("appointments").HasKey(a => a.Number);
        modelBuilder.Entity<Exam>().ToTable("exams").HasKey(e => e.Code);
    }
}

public abstract class Person {
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Doctor : Person {
    public string Code { get; set; }
    public string Specialization { get; set; }
    public float Salary { get; set; }
}

public class Patient : Person {
    public string Cpf { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
}

public class Appointment {
    public int Number { get; set; }
    public Patient Patient{ get; set; }
    public Doctor Doctor{ get; set; }
    public List<Exam> Exams { get; set; }
    public DateTime Date { get; set; }
}

public class Exam {
    public string Code { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public List<Appointment> Appointments { get; set; }
}
