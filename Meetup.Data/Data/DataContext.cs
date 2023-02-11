using Meetup.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Data.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Place> Places { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organizer>().HasData(
                new Organizer[]
                {
                    new Organizer{Id = 1,Name = "Hi-Tech Park"},
                    new Organizer{Id = 2,Name = "OOO Systems"}
                });

            modelBuilder.Entity<Place>().HasData(
                new Place[]
                {
                    new Place{Id = 1,Name = "Chelyuskintsev park"},
                    new Place{Id = 2,Name = "Gorky Park"}
                });
        }
    }
}
