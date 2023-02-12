using MediatR;
using Meetup.Application.Commands;
using Meetup.Application.Queries;
using Meetup.Application.ViewModels.EventViewModels; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MeetupWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Events")]
        [Authorize]
        public async Task<IActionResult> GetAllEvents()
        {
            var query = new GetAllEventsQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("EventById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetEventById(int id)
        {
            var eventVm = await _mediator.Send(new GetEventByIdQuery()
            {
                Id = id
            });

            return eventVm != null ? Ok(eventVm) : NotFound();
        }

        [HttpPost("AddEvent")]
        [Authorize]
        public async Task<IActionResult> AddEvent([FromBody] EventForCreationViewModel newEvent)
        {
            await _mediator.Send(new AddEventCommand()
            {
                Event = newEvent
            });

            return Ok();
        }

        [HttpDelete("DeleteEvent/{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteEvent(int id)
        {
            await _mediator.Send(new DeleteEventCommand()
            {
                Id = id
            });

            return NoContent();
        }

        [HttpPut("UpdateEvent/{id}")]
        [Authorize]
        public async Task<ActionResult> UpdateEvent(int id, [FromBody]EventForUpdateViewModel updatedEvent)
        {
            await _mediator.Send(new UpdateEventCommand()
            {
                Id = id,
                Event = updatedEvent
            });

            return Ok();
        }
    }
}
