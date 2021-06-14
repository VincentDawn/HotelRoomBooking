using System.Linq;

namespace HotelRoomBookingDAL.IRepository
{
    public interface IBaseEntityRepository<out O, in I>
    {
        IQueryable<O> Get();

        O CreateUpdate(I entity);
    }
}
