using System.Reflection;
using DesafioUbc.Business.Entitys;
using DesafioUbc.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DesafioUbc.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<User> User { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Username = "admin", Password = "admin" });
    }
}