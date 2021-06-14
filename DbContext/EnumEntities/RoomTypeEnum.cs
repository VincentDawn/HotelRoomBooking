using System.ComponentModel;

namespace HotelRoomCodeFirstDb.EnumEntities
{
    public enum RoomTypeEnum
    {
        [Description("Single")]
        Single = 1,

        [Description("Double")]
        Double = 2,

        [Description("Deluxe")]
        Deluxe = 3
    }
}
