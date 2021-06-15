using HotelRoomBookingBLL.DTO;
using System;
using System.Collections.Generic;

namespace HotelRoomBookingBLL.IHelpers
{
    public interface IBookingHelper
    {
        BookingDTO BookRoom(int roomId, DateTime dateStart, DateTime dateEnd, int guestCount);
        BookingDTO GetBookingByReferenceNumber(Guid referenceNumber); // Now the spec says reference number not booking number!
        List<BookingDTO> Get();
    }
}
