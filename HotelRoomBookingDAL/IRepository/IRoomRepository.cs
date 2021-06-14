using HotelRoomCodeFirstDb.Entities;

namespace HotelRoomBookingDAL.IRepository
{
    public interface IRoomRepository : IBaseEntityRepository<Room, Room>
    {
        //IQueryable<Room> GetRooms();

        //Room CreateUpdateRoom(Room room);
    }
}
