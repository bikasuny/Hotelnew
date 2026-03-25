using Hotel.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Core.DataContext
{
    public class HotelDbContext: DbContext
    {
        public HotelDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<CityHotel> hotels { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<User> users { get; set; }

    }
}
