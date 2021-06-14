using HotelRoomBookingBLL.IHelpers;
using HotelRoomBookingDAL.IRepository;

namespace HotelRoomBookingBLL.Helpers
{
    public class TestHelper : ITestHelper
    {
        private readonly ITestRepository _testRepository;

        public TestHelper(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public bool Reset()
        {
            return TearDown() && SetUp();
        }

        public bool SetUp()
        {
            return _testRepository.SetUp();
        }

        public bool TearDown()
        {
            return _testRepository.TearDown();
        }
    }
}
