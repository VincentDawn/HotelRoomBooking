using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelRoomCodeFirstDb.Entities
{
    // Association table
    public class BookingToRoom
    {
        // I misread and I don't even need this table. But leaving it in as demo for M:M
        [Key, Column(Order = 1)] // Compound key part 1
        public int BookingId { get; set; }

        [Key, Column(Order = 2)] // Compound key part 1
        public int RoomId { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual Room Room { get; set; }
    }
}
