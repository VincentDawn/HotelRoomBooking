using System;
using System.ComponentModel.DataAnnotations;

namespace HotelRoomBookingBLL.DTO
{
    public class BookingDTO
    {
        public int BookingId { get; set; } // Generally not a fan of exposing the PK, depends on visibility of the API or who is using it suppose

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; } // Will presume there's always an end date supplied

        [Required]
        [MaxLength(36)]
        public Guid BookingReference { get; set; }

        public virtual RoomDTO Room { get; set; }
    }
}
