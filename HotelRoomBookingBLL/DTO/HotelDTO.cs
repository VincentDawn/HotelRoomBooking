using System.Collections.Generic;

namespace HotelRoomBookingBLL.DTO
{
    public class HotelDTO
    {
        public int HotelId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<RoomDTO> Rooms { get; set; }

        public virtual ICollection<BookingDTO> Bookings { get; set; }
    }
}
