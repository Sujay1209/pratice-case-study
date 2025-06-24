using DAL.Models;
using DAL.Models.DAL.Models;
using System.Collections.Generic;

namespace DAL.DataAccess
{
    public class EventDetailsBL
    {
        private readonly IEventDetailsRepo _repo;

        public EventDetailsBL(IEventDetailsRepo repo)
        {
            _repo = repo;
        }

        // Add a new event
        public EventDetails AddEvent(EventDetails evt)
        {
            return _repo.AddEvent(evt);
        }

        // Update an existing event
        public EventDetails UpdateEvent(EventDetails evt)
        {
            return _repo.UpdateEvent(evt);
        }

        // Delete an event (by object)
        public EventDetails DeleteEvent(EventDetails evt)
        {
            return _repo.DeleteEvent(evt);
        }

        // Delete an event by ID (helper method)
        public EventDetails DeleteEvent(int eventId)
        {
            var evt = _repo.GetEventById(eventId);
            if (evt != null)
            {
                return _repo.DeleteEvent(evt);
            }
            return null;
        }

        // Get a single event by ID
        public EventDetails GetEventById(int id)
        {
            return _repo.GetEventById(id);
        }

        // Get all events
        public List<EventDetails> GetAllEvents()
        {
            return _repo.GetAllEvents();
        }

        // Optional: Filter events by category (if repo supports it)
        public List<EventDetails> GetEventsByCategory(string category)
        {
            if (_repo is IEventDetailsCategoryFilter categoryRepo)
            {
                return categoryRepo.GetEventsByCategory(category);
            }
            return new List<EventDetails>();
        }
    }

    // Optional interface for category filtering (if needed)
    public interface IEventDetailsCategoryFilter
    {
        List<EventDetails> GetEventsByCategory(string category);
    }
}
