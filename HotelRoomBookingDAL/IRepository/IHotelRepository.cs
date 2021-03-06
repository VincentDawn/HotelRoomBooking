using HotelRoomCodeFirstDb.Entities;
using System.Linq;

namespace HotelRoomBookingDAL.IRepository
{
    public interface IHotelRepository
    {
        IQueryable<Hotel> GetHotels();
    }
}
