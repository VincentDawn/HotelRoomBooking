using HotelRoomCodeFirstDb.Entities;

namespace HotelRoomBookingDAL.IRepository
{
    public interface IHotelRepository : IBaseEntityRepository<Hotel, Hotel>
    {
        //IQueryable<Hotel> GetHotels();

        //Hotel CreateUpdateHotel(Hotel hotel);
    }
}
