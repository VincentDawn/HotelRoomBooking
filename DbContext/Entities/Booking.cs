using System;
using System.ComponentModel.DataAnnotations;

namespace HotelRoomCodeFirstDb.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }

        [Required]
        public DateTime DateCreated { get; set; } // Created, Modified, and other properties on entities (excluding enums, association etc) could be included in a base "NormalTable" entity and inherited. Along with "Id" for PK but I'm only going to include these here as the Company, Hotel, and Rooms are going to be populated via seeding.

        public DateTime? DateModified { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; } // Will presume there's always an end date supplied

        [Required]
        [MaxLength(36)]
        public Guid BookingReference { get; set; } // spec says "BookingNumber" but I want to use a GUID and I don't want to append "Number"

        public int RoomId { get; set; }


        public virtual Room Room { get; set; }
    }
}
