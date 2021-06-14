using HotelRoomCodeFirstDb.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelRoomCodeFirstDb
{
    public class HotelRoomDbContext : DbContext
    {
        public HotelRoomDbContext(DbContextOptions<HotelRoomDbContext> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Entity type 'BookingToRoom' has composite primary key defined with data annotations. To set composite primary key, use fluent API.
            modelBuilder.Entity<BookingToRoom>()
                .HasKey(c => new { c.BookingId, c.RoomId });
        }

        public DbSet<Booking> Booking { get; set; }
        public DbSet<BookingToRoom> BookingToRoom { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomType> RoomType { get; set; }
    }
}
