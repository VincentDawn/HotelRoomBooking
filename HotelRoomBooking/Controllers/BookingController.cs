using HotelRoomBookingBLL.DTO;
using HotelRoomBookingBLL.IHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace HotelRoomBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingHelper _bookingHelper;
        private readonly IHotelHelper _hotelHelper;
        private readonly IRoomHelper _roomHelper;
        private readonly ILogger<BookingController> _logger;

        public BookingController(IBookingHelper bookingHelper, IHotelHelper hotelHelper, IRoomHelper roomHelper, ILogger<BookingController> logger)
        {
            _bookingHelper = bookingHelper;
            _hotelHelper = hotelHelper;
            _roomHelper = roomHelper;
            _logger = logger;
        }

        [HttpGet("GetHotelByName/{name}")] // In URL and not querystring example
        public ActionResult<HotelDTO> GetHotelByName(string name)
        {
            try
            {
                return Ok(_hotelHelper.GetHotelByName(name));
            }
            catch (Exception ex)
            {
                // Log some some useful information. Exception and the querystring for a get?
                _logger.LogError("Exception - BookingController - GetHotelByName", ex, Request.QueryString);
                throw;
            }
        }

        [HttpGet("FindRooms")]
        public ActionResult<RoomDTO> FindRooms(DateTime dateStart, DateTime dateEnd, int guestCount)
        {
            try
            {
                return Ok(_roomHelper.AvailableRooms(dateStart, dateEnd, guestCount));
            }
            catch (Exception ex)
            {
                // Log some some useful information. Exception and the querystring for a get?
                _logger.LogError("Exception - BookingController - FindRooms", ex, Request.QueryString);
                throw;
            }
        }

        [HttpGet("GetBookingDetails")]
        public ActionResult<BookingDTO> GetBookingDetails(Guid guid)
        {
            try
            {
                return Ok(_bookingHelper.GetBookingByReferenceNumber(guid));
            }
            catch (Exception ex)
            {
                // Log some some useful information. Exception and the querystring for a get?
                _logger.LogError("Exception - BookingController - GetBookingDetails", ex, Request.QueryString);
                throw;
            }
        }

        // I could make request object for this and add it to the parms for modelbinding but wont due to time constraints
        [HttpPost("BookRoom")]
        public ActionResult<BookingDTO> BookRoom(int RoomId, DateTime dateStart, DateTime dateEnd, int guestCount)
        {
            try
            {
                return Ok(_bookingHelper.BookRoom(RoomId, dateStart, dateEnd, guestCount));
            }
            catch (Exception ex)
            {
                // Log some some useful information. Exception and the not sure if the form will work correctly in tostring.
                _logger.LogError("Exception - BookingController - BookRoom", ex, Request.Form.ToString());
                throw;
            }
        }
    }
}
