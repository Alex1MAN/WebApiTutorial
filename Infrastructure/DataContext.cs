namespace WebApi.Helpers;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApi.Entities;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }

    private readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // in memory database used for simplicity, change to a real db for production applications
        // options.UseInMemoryDatabase("TestDb");

        //options.UseNpgsql("Host=localhost;Port=5432;Database=TestTPT2;Username=postgres;Password=root");
        options.UseNpgsql(Configuration.GetConnectionString("local"));
    }
}