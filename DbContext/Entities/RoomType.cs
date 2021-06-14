using HotelRoomCodeFirstDb.EnumEntities;
using System.ComponentModel.DataAnnotations;

namespace HotelRoomCodeFirstDb.Entities
{
    public class RoomType
    {
        public RoomTypeEnum RoomTypeId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
