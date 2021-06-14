using HotelRoomCodeFirstDb.EnumEntities;
using System.ComponentModel.DataAnnotations;

namespace HotelRoomCodeFirstDb.Entities
{
    public class Room
    {
        public int RoomId { get; set; }

        public int HotelId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public int RoomNumber { get; set; }

        public int BedCount { get; set; } // Assuming that room type doesn't define this as I guess a Deluxe could be  2 bed as well so I can't use the enum constant? I'm no hotel expert

        public bool HasBathroom { get; set; }

        [Required]
        public RoomTypeEnum RoomType { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
