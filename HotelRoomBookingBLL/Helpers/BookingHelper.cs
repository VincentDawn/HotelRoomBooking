using AutoMapper;
using HotelRoomBookingBLL.DTO;
using HotelRoomBookingBLL.IHelpers;
using HotelRoomBookingDAL.IRepository;
using HotelRoomCodeFirstDb.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelRoomBookingBLL.Helpers
{
    // I'd consider separate helpers more but I just want to demonstrate implementing multiple interfaces
    public class BookingHelper : IBookingHelper, IHotelHelper, IRoomHelper
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public BookingHelper(IBookingRepository bookingRepository, IHotelRepository hotelRepository, IRoomRepository roomRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _hotelRepository = hotelRepository;
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public List<RoomDTO> AvailableRooms(DateTime dateStart, DateTime dateEnd, int guestCount)
        {
            return _mapper.Map<List<RoomDTO>>(_roomRepository.GetRooms().Include(x => x.Bookings)
                .Where(x => x.Bookings.Where(y => y.DateStart < dateEnd && dateStart < y.DateEnd).Count() == 0 && x.BedCount >= guestCount));
        }

        public BookingDTO BookRoom(int roomId, DateTime dateStart, DateTime dateEnd, int guestCount)
        {
            if (CanBookRoom(roomId, dateStart, dateEnd, guestCount))
            {
                var booking = new Booking()
                {
                    BookingReference = new Guid(),
                    DateCreated = DateTime.UtcNow,
                    DateEnd = dateEnd,
                    DateStart = dateStart,
                    RoomId = roomId
                };

                return _mapper.Map<BookingDTO>(_bookingRepository.CreateUpdate(booking));
            }

            return null;
        }

        public bool CanBookRoom(int roomId, DateTime dateStart, DateTime dateEnd, int guestCount)
        {
            // Any overlap?
            return _bookingRepository.Get()
                .Include(x => x.Room)
                .Where(x => x.RoomId == roomId && x.Room.BedCount >= guestCount)
                // We have bookings for this room, are there any which overlap
                .Any(x => !(x.DateStart < dateEnd && dateStart < x.DateEnd));
        }

        public BookingDTO GetBookingByReferenceNumber(Guid referenceNumber)
        {
            return _mapper.Map<BookingDTO>(_bookingRepository.Get().FirstOrDefault(x => x.BookingReference == referenceNumber));
        }

        public HotelDTO GetHotelByName(string name)
        {
            var hotel = _hotelRepository.GetHotels()
                .FirstOrDefault(x => x.Name == name);

            return _mapper.Map<HotelDTO>(hotel);
        }
    }
}
