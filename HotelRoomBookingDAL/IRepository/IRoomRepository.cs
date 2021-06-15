using HotelRoomCodeFirstDb.Entities;
using System.Linq;

namespace HotelRoomBookingDAL.IRepository
{
    public interface IRoomRepository
    {
        IQueryable<Room> GetRooms();
    }
}
