using HotelRoomBookingBLL.IHelpers;
using Microsoft.AspNetCore.Mvc;

namespace HotelRoomBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestHelper _testHelper;

        public TestController(ITestHelper testHelper)
        {
            _testHelper = testHelper;
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
    }
}
