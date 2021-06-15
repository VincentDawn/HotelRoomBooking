using HotelRoomBookingBLL.DTO;

namespace HotelRoomBookingBLL.IHelpers
{
    public interface IHotelHelper
    {
        HotelDTO GetHotelByName(string name);
    }
}
