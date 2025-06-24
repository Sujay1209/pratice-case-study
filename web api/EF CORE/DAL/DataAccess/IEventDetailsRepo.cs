using System.Collections.Generic;

namespace DAL.DataAccess
{
    public interface IEventDetailsRepo<T>
    {
        T AddEvent(T evt);
        T UpdateEvent(T evt);
        T DeleteEvent(T evt);
        T GetEventById(int eventId);
        List<T> GetAllEvents();
    }
}
