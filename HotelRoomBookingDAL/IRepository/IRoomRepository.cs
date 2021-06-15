using HotelRoomCodeFirstDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelRoomBookingDAL.IRepository
{
    public interface IRoomRepository
    {
        IQueryable<Room> GetRooms();
    }
}
