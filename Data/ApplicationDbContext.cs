using EksamenGruppe7.Models;
using Microsoft.EntityFrameworkCore;

namespace EksamenGruppe7.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Tilpass modeller her om nødvendig
        }
    }
}
