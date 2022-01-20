using Microsoft.EntityFrameworkCore;

namespace TennisCourt.Models
{
    public class TennisCourtContext : DbContext
    {
        public TennisCourtContext(DbContextOptions<TennisCourtContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
          {
            builder.Entity<Court>()
                .HasData(
                    new Court { CourtId = 3, Name = "Seattle Tennis Club", City = "Seattle", State = "Washington", SurfaceType = "Hard" , Address ="1111 Interlake N", Public = true},
                    new Court { CourtId = 4, Name = "Fargo Community Center", City = "Fargo", State = "North Dakota", SurfaceType = "Grass" , Address ="2314 Denny way N", Public = true},
                    new Court { CourtId = 5, Name = "Portland University Court", City = "Portland", State = "Oregon", SurfaceType = "Hard" , Address ="700 Rex st SE", Public = true},
                    new Court { CourtId = 6, Name = "Spokane Court", City = "Spokane", State = "Washington", SurfaceType = "Hard" , Address ="1245 Spokane Way N", Public = true},
                    new Court { CourtId = 7, Name = "San Francisco Tennis Club", City = "San Francisco", State = "California", SurfaceType = "Clay" , Address ="435 Lynn S", Public = false}
                );
          }

        public DbSet<Court> Courts { get; set; }
    }
}

