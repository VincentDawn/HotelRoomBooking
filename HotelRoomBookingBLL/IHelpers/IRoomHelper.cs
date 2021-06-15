using HotelRoomBookingBLL.DTO;
using System;
using System.Collections.Generic;

namespace HotelRoomBookingBLL.IHelpers
{
    public interface IRoomHelper
    {
        List<RoomDTO> AvailableRooms(DateTime dateStart, DateTime dateEnd, int guestCount); // Random non-queryable version
    }
}
