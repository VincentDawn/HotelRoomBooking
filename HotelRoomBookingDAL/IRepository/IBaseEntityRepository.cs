using System.Linq;

namespace HotelRoomBookingDAL.IRepository
{
    public interface IBaseEntityRepository<out O, in I>
    {
        // I was going to try some generics. If this isn't used it's be
        IQueryable<O> Get();

        O CreateUpdate(I entity);
    }
}
