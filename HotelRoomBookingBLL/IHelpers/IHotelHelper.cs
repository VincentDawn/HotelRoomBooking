using HotelRoomBookingBLL.DTO;
using System.Collections.Generic;

namespace HotelRoomBookingBLL.IHelpers
{
    public interface IHotelHelper
    {
        HotelDTO GetHotelByName(string name);
        List<HotelDTO> Get();
    }
}
