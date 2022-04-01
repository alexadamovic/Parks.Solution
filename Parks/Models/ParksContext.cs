using Microsoft.EntityFrameworkCore;

namespace Parks.Models
{
    public class ParksContext : DbContext
    {
        public ParksContext(DbContextOptions<ParksContext> options)
            : base(options)
        {
        }

        public DbSet<Park> Parks { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
          builder.Entity<Park>()
              .HasData(
                  new Park { ParkId = 1, Name = "Crater Lake", IsStatePark = false, IsNationalPark = true, LocationId = 1 },
                  new Park { ParkId = 2, Name = "Black Canyon of the Gunnison", IsStatePark = false, IsNationalPark = true, LocationId = 2 },
                  new Park { ParkId = 3, Name = "Mesa Verde", IsStatePark = false, IsNationalPark = true, LocationId = 2 },
                  new Park { ParkId = 4, Name = "Haleakala", IsStatePark = false, IsNationalPark = true, LocationId = 3 },
                  new Park { ParkId = 5, Name = "Joshua Tree", IsStatePark = false, IsNationalPark = true, LocationId = 4 },
                  new Park { ParkId = 6, Name = "Death Valley", IsStatePark = false, IsNationalPark = true, LocationId = 4 },
                  new Park { ParkId = 7, Name = "Yosemite", IsStatePark = false, IsNationalPark = true, LocationId = 4 },
                  new Park { ParkId = 8, Name = "Agate Beach", IsStatePark = true, IsNationalPark = false, LocationId = 1 },
                  new Park { ParkId = 9, Name = "Tryon Creek", IsStatePark = true, IsNationalPark = false, LocationId = 1 },
                  new Park { ParkId = 10, Name = "Wailua River", IsStatePark = true, IsNationalPark = false, LocationId = 3 },
                  new Park { ParkId = 11, Name = "Moonlight Beach", IsStatePark = true, IsNationalPark = false, LocationId = 4 },
                  new Park { ParkId = 12, Name = "San Bruno Mountain", IsStatePark = true, IsNationalPark = false, LocationId = 4 },
                  new Park { ParkId = 13, Name = "Sweitzer Lake", IsStatePark = true, IsNationalPark = false, LocationId = 2 },
                  new Park { ParkId = 14, Name = "Roxborough", IsStatePark = true, IsNationalPark = false, LocationId = 2 }
              );
          builder.Entity<Location>()
              .HasData(
                  new Location { LocationId = 1, State = "OR" },
                  new Location { LocationId = 2, State = "CO" },
                  new Location { LocationId = 3, State = "HI" },
                  new Location { LocationId = 4, State = "CA" }
              );
        }
    }
}