using CinemaTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaTickets.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Actor>Actors { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Actor_Movie> Actor_Movies { get; set; }
        public DbSet<Producer> producers { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
