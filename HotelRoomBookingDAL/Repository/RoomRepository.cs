using HotelRoomBookingDAL.IRepository;
using HotelRoomCodeFirstDb;
using HotelRoomCodeFirstDb.Entities;
using System.Linq;

namespace HotelRoomBookingDAL.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelBookingDbContext _dbContext;

        public RoomRepository(HotelBookingDbContext hotelBookingDbContext)
        {
            _dbContext = hotelBookingDbContext;
        }

        public IQueryable<Room> GetRooms()
        {
            return _dbContext.Room;
        }
    }
}
