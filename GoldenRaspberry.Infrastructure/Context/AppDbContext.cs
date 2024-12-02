using GoldenRaspberry.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoldenRaspberry.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("GoldenRaspberryAwardsDB");
        }
    }
}
