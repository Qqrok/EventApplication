using DataLayer.Models.Configs;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Extensions
{
    public class EventAppContext : DbContext
    {
        public EventAppContext(DbContextOptions<EventAppContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<UserEvent> UserEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
            modelBuilder.ApplyConfiguration(new UserEventConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
