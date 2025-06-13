using DAL.Models;
using DAL.Models.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DataAccess
{
    public class EventDetailsRepo : IEventDetailsRepo
    {
        private readonly EventDbContext _context;

        public EventDetailsRepo(EventDbContext context)
        {
            _context = context;
        }

        public EventDetails AddEvent(EventDetails evt)
        {
            _context.EventDetails.Add(evt);
            _context.SaveChanges();
            return evt;
        }

        public EventDetails UpdateEvent(EventDetails evt)
        {
            _context.EventDetails.Update(evt);
            _context.SaveChanges();
            return evt;
        }

        public EventDetails DeleteEvent(EventDetails evt)
        {
            _context.EventDetails.Remove(evt);
            _context.SaveChanges();
            return evt;
        }

        public EventDetails GetEventById(int eventId)
        {
            return _context.EventDetails.Find(eventId);
        }

        public List<EventDetails> GetAllEvents()
        {
            return _context.EventDetails.ToList();
        }
    }
}
