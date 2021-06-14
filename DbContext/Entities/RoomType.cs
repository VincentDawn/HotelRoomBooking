using HotelRoomCodeFirstDb.EnumEntities;
using System.ComponentModel.DataAnnotations;
using static HotelRoomCodeFirstDb.Converters.EnumFunctions;

namespace HotelRoomCodeFirstDb.Entities
{
    public class RoomType : IEnumModel<RoomType, RoomTypeEnum>
    {
        public RoomTypeEnum Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
