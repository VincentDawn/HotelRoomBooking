using HotelRoomBookingDAL.IRepository;
using HotelRoomCodeFirstDb;
using HotelRoomCodeFirstDb.Entities;
using HotelRoomCodeFirstDb.EnumEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace HotelRoomBookingDAL.Repository
{
    public class TestRepository : ITestRepository
    {
        private readonly HotelBookingDbContext _dbContext;

        public TestRepository(HotelBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool SetUp()
        {
            _dbContext.Database.Migrate();
            // Add 2 company
            // Add 3 hotels
            // "Hotels have 6 rooms" Will have 2 hotels with at least 6

            // Also to seed booking dates?

            // Just going to keep the names and numbers simple
            // Still not sure about "deluxe" and capacity
            var companies = new List<Company>()
            {
                new Company(){ Name = "Company 1", Hotels = new List<Hotel>()
                {
                    new Hotel(){ Name = "Hotel 1", Rooms = new List<Room>()
                    {
                        new Room(){ BedCount = 1, HasBathroom = false, Name = "Room 1", RoomNumber = 1, RoomType = RoomTypeEnum.Single },
                        new Room(){ BedCount = 2, HasBathroom = false, Name = "Room 2", RoomNumber = 2, RoomType = RoomTypeEnum.Double },
                        new Room(){ BedCount = 2, HasBathroom = true, Name = "Room 3", RoomNumber = 3, RoomType = RoomTypeEnum.Deluxe },
                        new Room(){ BedCount = 1, HasBathroom = true, Name = "Room 4", RoomNumber = 4, RoomType = RoomTypeEnum.Single },
                        new Room(){ BedCount = 2, HasBathroom = true, Name = "Room 5", RoomNumber = 5, RoomType = RoomTypeEnum.Double },
                        new Room(){ BedCount = 3, HasBathroom = true, Name = "Room 6", RoomNumber = 6, RoomType = RoomTypeEnum.Deluxe },
                    } },
                    new Hotel(){ Name = "Hotel 2", Rooms = new List<Room>()
                    {
                        new Room(){ BedCount = 1, HasBathroom = false, Name = "Room 1", RoomNumber = 1, RoomType = RoomTypeEnum.Single },
                        new Room(){ BedCount = 2, HasBathroom = false, Name = "Room 2", RoomNumber = 2, RoomType = RoomTypeEnum.Double },
                        new Room(){ BedCount = 3, HasBathroom = true, Name = "Room 3", RoomNumber = 3, RoomType = RoomTypeEnum.Deluxe },
                        new Room(){ BedCount = 4, HasBathroom = true, Name = "Room 4", RoomNumber = 4, RoomType = RoomTypeEnum.Deluxe },
                        new Room(){ BedCount = 5, HasBathroom = true, Name = "Room 5", RoomNumber = 5, RoomType = RoomTypeEnum.Deluxe },
                        new Room(){ BedCount = 6, HasBathroom = true, Name = "Room 6", RoomNumber = 6, RoomType = RoomTypeEnum.Deluxe },
                    } }
                } },
                new Company(){ Name = "Company 2", Hotels = new List<Hotel>()
                {
                    new Hotel(){ Name = "Hotel 3", Rooms = new List<Room>()
                    {
                        new Room(){ BedCount = 1, HasBathroom = true, Name = "Room 1", RoomNumber = 1, RoomType = RoomTypeEnum.Single },
                        new Room(){ BedCount = 1, HasBathroom = true, Name = "Room 2", RoomNumber = 2, RoomType = RoomTypeEnum.Single },
                        new Room(){ BedCount = 1, HasBathroom = true, Name = "Room 3", RoomNumber = 3, RoomType = RoomTypeEnum.Single },
                        new Room(){ BedCount = 2, HasBathroom = true, Name = "Room 4", RoomNumber = 4, RoomType = RoomTypeEnum.Double },
                    } },
                    new Hotel(){ Name = "Hotel 4", Rooms = new List<Room>()
                    {
                        // Penthouse or something?
                        new Room(){ BedCount = 10, HasBathroom = true, Name = "Room 1", RoomNumber = 1, RoomType = RoomTypeEnum.Deluxe },
                        new Room(){ BedCount = 20, HasBathroom = true, Name = "Room 2", RoomNumber = 2, RoomType = RoomTypeEnum.Deluxe },
                    } }
                } }
            };

            List<Booking> bookings = new List<Booking>()
            {
                new Booking(){ BookingReference = Guid.NewGuid(), DateCreated = DateTime.UtcNow, DateEnd = DateTime.UtcNow.AddDays(18), DateStart = DateTime.UtcNow.AddDays(9), RoomId = 1 },
                new Booking(){ BookingReference = Guid.NewGuid(), DateCreated = DateTime.UtcNow, DateEnd = DateTime.UtcNow.AddDays(8), DateStart = DateTime.UtcNow.AddDays(1), RoomId = 1 },
                new Booking(){ BookingReference = Guid.NewGuid(), DateCreated = DateTime.UtcNow, DateEnd = DateTime.UtcNow.AddDays(16), DateStart = DateTime.UtcNow.AddDays(8), RoomId = 3 },
                new Booking(){ BookingReference = Guid.NewGuid(), DateCreated = DateTime.UtcNow, DateEnd = DateTime.UtcNow.AddDays(24), DateStart = DateTime.UtcNow.AddDays(17), RoomId = 3 },
                new Booking(){ BookingReference = Guid.NewGuid(), DateCreated = DateTime.UtcNow, DateEnd = DateTime.UtcNow.AddDays(14), DateStart = DateTime.UtcNow.AddDays(7), RoomId = 5 },
                new Booking(){ BookingReference = Guid.NewGuid(), DateCreated = DateTime.UtcNow, DateEnd = DateTime.UtcNow.AddDays(12), DateStart = DateTime.UtcNow.AddDays(6), RoomId = 7 },
                new Booking(){ BookingReference = Guid.NewGuid(), DateCreated = DateTime.UtcNow, DateEnd = DateTime.UtcNow.AddDays(10), DateStart = DateTime.UtcNow.AddDays(5), RoomId = 9 },
                new Booking(){ BookingReference = Guid.NewGuid(), DateCreated = DateTime.UtcNow, DateEnd = DateTime.UtcNow.AddDays(8), DateStart = DateTime.UtcNow.AddDays(4), RoomId = 11 },
                new Booking(){ BookingReference = Guid.NewGuid(), DateCreated = DateTime.UtcNow, DateEnd = DateTime.UtcNow.AddDays(6), DateStart = DateTime.UtcNow.AddDays(3), RoomId = 13 },
                new Booking(){ BookingReference = Guid.NewGuid(), DateCreated = DateTime.UtcNow, DateEnd = DateTime.UtcNow.AddDays(-4), DateStart = DateTime.UtcNow.AddDays(-8), RoomId = 15 },
                new Booking(){ BookingReference = Guid.NewGuid(), DateCreated = DateTime.UtcNow, DateEnd = DateTime.UtcNow.AddDays(-2), DateStart = DateTime.UtcNow.AddDays(-10), RoomId = 17 }
            };

            _dbContext.AddRange(companies);
            _dbContext.SaveChanges();

            _dbContext.AddRange(bookings);

            return _dbContext.SaveChanges() > 1;
        }

        public bool TearDown()
        {
            return _dbContext.Database.EnsureDeleted();
        }
    }
}
