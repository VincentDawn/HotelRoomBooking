using HotelRoomBookingBLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelRoomBookingBLL.IHelpers
{
    public interface IRoomHelper
    {
        List<RoomDTO> AvailableRooms(DateTime dateStart, DateTime dateEnd, int guestCount); // Random non-queryable version
    }
}
