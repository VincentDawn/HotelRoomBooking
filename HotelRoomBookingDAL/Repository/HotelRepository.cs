using HotelRoomBookingDAL.IRepository;
using HotelRoomCodeFirstDb;
using HotelRoomCodeFirstDb.Entities;
using System.Linq;

namespace HotelRoomBookingDAL.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelBookingDbContext _dbContext;

        public HotelRepository(HotelBookingDbContext hotelBookingDbContext)
        {
            _dbContext = hotelBookingDbContext;
        }

        public IQueryable<Hotel> GetHotels()
        {
            return _dbContext.Hotel;
        }
    }
}
