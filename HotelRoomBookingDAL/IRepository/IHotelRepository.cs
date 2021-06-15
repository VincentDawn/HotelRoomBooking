using HotelRoomCodeFirstDb.Entities;
using System.Linq;

namespace HotelRoomBookingDAL.IRepository
{
    public interface IHotelRepository : IBaseEntityRepository<Hotel, Hotel>
    {
        IQueryable<Hotel> GetHotels();
    }
}
