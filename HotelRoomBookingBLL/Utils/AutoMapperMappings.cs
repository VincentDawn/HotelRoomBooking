using AutoMapper;
using HotelRoomBookingBLL.DTO;
using HotelRoomCodeFirstDb.Entities;

namespace HotelRoomBookingBLL.Utils
{
    public class AutoMapperMappings : Profile
    {
        public AutoMapperMappings()
        {
            CreateMap<Booking, BookingDTO>();
            CreateMap<Company, CompanyDTO>();
            CreateMap<Hotel, HotelDTO>();
            CreateMap<Room, RoomDTO>();
        }
    }
}
