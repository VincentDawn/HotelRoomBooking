using HotelRoomCodeFirstDb.Converters;
using HotelRoomCodeFirstDb.Entities;
using HotelRoomCodeFirstDb.EnumEntities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

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

            // I could do the seeding here or add it in an extension method, but it appears the spec says we need setup and teardown methods after startup

            // Will seed the lookups
            modelBuilder.Entity<RoomType>().HasData(EnumFunctions.GetModelsFromEnum<RoomType, RoomTypeEnum>());

            // Alternate key
            modelBuilder.Entity<Booking>().HasAlternateKey(x => x.BookingReference);
            modelBuilder.Entity<Booking>().HasIndex(x => x.BookingReference);
        }

        public DbSet<Booking> Booking { get; set; }
        public DbSet<BookingToRoom> BookingToRoom { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomType> RoomType { get; set; }
    }
}
