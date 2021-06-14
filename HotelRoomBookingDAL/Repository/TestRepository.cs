using HotelRoomBookingDAL.IRepository;
using HotelRoomCodeFirstDb;
using HotelRoomCodeFirstDb.Entities;
using HotelRoomCodeFirstDb.EnumEntities;
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


            _dbContext.AddRange(companies);
            return _dbContext.SaveChanges() > 1;
        }

        public bool TearDown()
        {
            // Delete companies and it'll all cascade?
            _dbContext.Company.RemoveRange(_dbContext.Company);
            return _dbContext.SaveChanges() > 1;
        }
    }
}
