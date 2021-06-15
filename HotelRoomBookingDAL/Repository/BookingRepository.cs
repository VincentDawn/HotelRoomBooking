using HotelRoomBookingDAL.IRepository;
using HotelRoomCodeFirstDb;
using HotelRoomCodeFirstDb.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HotelRoomBookingDAL.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HotelBookingDbContext _dbContext;

        public BookingRepository(HotelBookingDbContext hotelBookingDbContext)
        {
            _dbContext = hotelBookingDbContext;
        }
        public Booking CreateUpdate(Booking entity)
        {
            var existingEntity = _dbContext.Booking.Find(entity);

            if (existingEntity != null)
            {
                _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            }
            else
            {
                _dbContext.Add(entity);
            }

            _dbContext.SaveChanges();

            return entity;
        }

        public IQueryable<Booking> Get()
        {
            return _dbContext.Booking.Include(x => x.Room).ThenInclude(x => x.Hotel); // Include the room and hotel in this so we can see the room number and hotel name
        }
    }
}
