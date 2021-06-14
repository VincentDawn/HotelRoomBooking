namespace HotelRoomBookingBLL.IHelpers
{
    public interface ITestHelper
    {
        bool SetUp();
        bool TearDown();

        /// <summary>
        /// Runs TearDown method and then SetUp method.
        /// </summary>
        /// <returns>If successfull.</returns>
        bool Reset();
    }
}
