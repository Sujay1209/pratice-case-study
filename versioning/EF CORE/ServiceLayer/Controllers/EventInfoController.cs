using DAL.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using DAL.Models.DAL.Models;
using Microsoft.AspNetCore.Cors;

namespace ServiceLayer.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [EnableCors("AllowGetAndPost")]
    public class EventInfoController : ControllerBase
    {
        private readonly IEventDetailsRepo<EventDetails> _eventDetailsRepo;

        public EventInfoController(IEventDetailsRepo<EventDetails> eventDetailsRepo)
        {
            this._eventDetailsRepo = eventDetailsRepo;
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllEvents()
        {
            var events= _eventDetailsRepo.GetAllEvents();
            return Ok(events);
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetEventById(int id) 
        {
            var events = _eventDetailsRepo.GetEventById(id);
            return Ok(events);
        }
        [HttpPost]
        [Route("SaveEvent")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public IActionResult AddEvent([FromBody] EventDetails evt)
        {
            if (evt != null)
            {
                _eventDetailsRepo.AddEvent(evt);
                return Created(HttpContext.Request.Path,evt);

            }
            else
            {
                return BadRequest();
            }

        }
        [HttpDelete]
        [Route("DeleteEvent/{id}")]
        [Produces("application/json")]
        public IActionResult DeleteEvent(int id)
        {
            // First, retrieve the event object by its ID
            var evt = _eventDetailsRepo.GetEventById(id);

            if (evt == null)
            {
                return NotFound($"Event with ID {id} not found.");
            }

            // Pass the full object to the Delete method
            var deleted = _eventDetailsRepo.DeleteEvent(evt);

            return Ok(deleted);
        }

        [HttpPut]
        [Route("UpdateProduct")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public IActionResult UpdateProduct([FromBody] EventDetails product)
        {
            var updatedProduct = _eventDetailsRepo.UpdateEvent(product);
            if (updatedProduct != null)
            {
                return Accepted(HttpContext.Request.Path, updatedProduct);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
