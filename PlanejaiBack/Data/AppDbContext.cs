using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PlanejaiBack.Models;

namespace PlanejaiBack.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<EventModel>? Events { get; set; }
        public DbSet<UserModel>? Users { get; set; }
        public DbSet<GuestModel>? Guests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().ToTable("Users").HasKey(u => u.Id);
            modelBuilder.Entity<GuestModel>().ToTable("Guests").HasKey(g => g.Id);
            modelBuilder.Entity<EventModel>().ToTable("Events").HasKey(e => e.Id);
        }
    }
}
