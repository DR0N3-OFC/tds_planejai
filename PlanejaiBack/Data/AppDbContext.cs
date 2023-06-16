using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PlanejaiBack.Models;
using System.Diagnostics;

namespace PlanejaiBack.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<EventModel>? Events { get; set; }
        public DbSet<UserModel>? Users { get; set; }
        public DbSet<GuestModel>? Guests { get; set; }
        public DbSet<EventsGuests>? EventsGuests { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().ToTable("Users").HasKey(u => u.UserId);
            modelBuilder.Entity<GuestModel>().ToTable("Guests").HasKey(g => g.GuestId);
            modelBuilder.Entity<EventModel>().ToTable("Events").HasKey(e => e.EventId);
            modelBuilder.Entity<EventsGuests>().HasKey(eg => new { eg.EventId, eg.GuestId });

            modelBuilder.Entity<EventModel>()
                .HasOne<UserModel>(u => u.Organizer)
                .WithMany(u => u.Events)
                .HasForeignKey(u => u.OrganizerId)
                .OnDelete(DeleteBehavior.Cascade); ;

            modelBuilder.Entity<EventsGuests>()
                .HasOne<EventModel>(eg => eg.Event)
                .WithMany(e => e.EventsGuests)
                .HasForeignKey(eg => eg.EventId);


            modelBuilder.Entity<EventsGuests>()
                .HasOne<GuestModel>(eg => eg.Guest)
                .WithMany(e => e.EventsGuests)
                .HasForeignKey(eg => eg.GuestId);
        }
    }
}
