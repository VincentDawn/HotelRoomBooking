using HotelRoomCodeFirstDb.EnumEntities;

namespace HotelRoomBookingBLL.DTO
{
    public class RoomDTO
    {
        public int RoomId { get; set; }

        public string Name { get; set; }

        public int RoomNumber { get; set; }

        public int BedCount { get; set; }

        public bool HasBathroom { get; set; }

        public RoomTypeEnum RoomType { get; set; }

        public virtual HotelDTO Hotel { get; set; }
        //public virtual ICollection<Booking> Bookings { get; set; }
    }
}
