using Microsoft.EntityFrameworkCore;

namespace Lab10.DataBase;

public class ApplicationContext : DbContext
{
    public DbSet<Animal> Animals { get; set; }
    public DbSet<Aviary> Aviaries { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public ApplicationContext()
    {

    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=PostgresDb;Username=User;Password=S3cret;");
    }
    
    
    
}