using HotelRoomCodeFirstDb.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelRoomCodeFirstDb
{
    public class HotelRoomDbContext : DbContext
    {
        public DbSet<Booking> Booking { get; set; }
        public DbSet<BookingToRoom> BookingToRoom { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomType> RoomType { get; set; }
    }
}
