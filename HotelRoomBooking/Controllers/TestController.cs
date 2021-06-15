using HotelRoomBookingBLL.IHelpers;
using Microsoft.AspNetCore.Mvc;

namespace HotelRoomBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestHelper _testHelper;
        private readonly IBookingHelper _bookingHelper;
        private readonly IHotelHelper _hotelHelper;
        private readonly IRoomHelper _roomHelper;

        public TestController(ITestHelper testHelper, IBookingHelper bookingHelper, IHotelHelper hotelHelper, IRoomHelper roomHelper)
        {
            _testHelper = testHelper;
            _bookingHelper = bookingHelper;
            _hotelHelper = hotelHelper;
            _roomHelper = roomHelper;
        }

        [HttpGet("TearDown")]
        public IActionResult TearDown()
        {
            return Ok(_testHelper.TearDown());
        }

        [HttpGet("SetUp")]
        public IActionResult SetUp()
        {
            return Ok(_testHelper.SetUp());
        }

        [HttpGet("Reset")]
        public IActionResult Reset()
        {
            return Ok(_testHelper.Reset());
        }

        // Some gets for all tables
        [HttpGet("GetBookings")]
        public IActionResult GetBookings()
        {
            return Ok(_bookingHelper.Get());
        }

        [HttpGet("GetRooms")]
        public IActionResult GetRooms() // Leaving these as non concrete type to show what happens and on swagger
        {
            return Ok(_roomHelper.Get());
        }

        [HttpGet("GetHotels")]
        public IActionResult GetHotels()
        {
            return Ok(_hotelHelper.Get());
        }
    }
}
