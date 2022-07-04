using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public DbSet<CarBrand> CarBrands { get; set; }
    public DbSet<CarModel> CarModels { get; set; }
    public DbSet<CarQueue> CarQueues { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<ClientCar> ClientCars { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<CompletedService> CompletedServices { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Instrument> Instruments { get; set; }
    public DbSet<ModelGeneration> ModelGenerations { get; set; }
    public DbSet<Place> Places { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Spare> Spares { get; set; }

    public ApplicationContext()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("host=localhost;port=5432;database=apidb;username=postgres;password=123;");
    }
}