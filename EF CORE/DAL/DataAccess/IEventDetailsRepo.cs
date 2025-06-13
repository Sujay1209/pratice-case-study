using DAL.Models;
using DAL.Models.DAL.Models;
using System.Collections.Generic;

namespace DAL.DataAccess
{
    public interface IEventDetailsRepo
    {
        EventDetails AddEvent(EventDetails evt);
        EventDetails UpdateEvent(EventDetails evt);
        EventDetails DeleteEvent(EventDetails evt);
        EventDetails GetEventById(int eventId);
        List<EventDetails> GetAllEvents();
    }
}
