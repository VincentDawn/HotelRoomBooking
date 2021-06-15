using HotelRoomCodeFirstDb.Entities;
using System.Linq;

namespace HotelRoomBookingDAL.IRepository
{
    public interface IRoomRepository : IBaseEntityRepository<Room, Room>
    {
        IQueryable<Room> GetRooms();
    }
}
