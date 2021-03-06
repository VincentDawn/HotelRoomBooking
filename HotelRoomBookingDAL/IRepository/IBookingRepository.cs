using HotelRoomCodeFirstDb.Entities;

namespace HotelRoomBookingDAL.IRepository
{
    public interface IBookingRepository : IBaseEntityRepository<Booking, Booking>
    {
        // Trying this one with generics
    }
}
