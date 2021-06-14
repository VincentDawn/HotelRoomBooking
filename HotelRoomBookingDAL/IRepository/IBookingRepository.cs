using HotelRoomCodeFirstDb.Entities;

namespace HotelRoomBookingDAL.IRepository
{
    public interface IBookingRepository : IBaseEntityRepository<Booking, Booking>
    {
        //IQueryable<Booking> GetBooking();

        //Booking CreateUpdateBooking(Booking booking);
    }
}
