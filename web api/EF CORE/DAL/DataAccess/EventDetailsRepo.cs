using DAL.Models;
using DAL.Models.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DataAccess
{
    public class EventDetailsRepo : IEventDetailsRepo<EventDetails>
    {
        public EventDetails AddEvent(EventDetails evt)
        {
            using (var context = new EventDbContext())
            {
                context.EventDetails.Add(evt);
                context.SaveChanges();
                return evt;
            }
        }

        public EventDetails UpdateEvent(EventDetails evt)
        {
            using (var context = new EventDbContext())
            {
                context.EventDetails.Update(evt);
                context.SaveChanges();
                return evt;
            }
        }

        public EventDetails DeleteEvent(EventDetails evt)
        {
            using (var context = new EventDbContext())
            {
                context.EventDetails.Remove(evt);
                context.SaveChanges();
                return evt;
            }
        }

        public EventDetails GetEventById(int eventId)
        {
            using (var context = new EventDbContext())
            {
                return context.EventDetails.Find(eventId);
            }
        }

        public List<EventDetails> GetAllEvents()
        {
            using (var context = new EventDbContext())
            {
                return context.EventDetails.ToList();
            }
        }
    }
}
