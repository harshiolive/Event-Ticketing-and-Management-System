using EventTicketingManagement.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateEvent([FromBody] Event eventObj)
    {
        var createdEvent = await _eventService.CreateEventAsync(eventObj);
        return CreatedAtAction(nameof(GetEventById), new { id = createdEvent.EventId }, createdEvent);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEventById(int id)
    {
        var eventObj = await _eventService.GetEventByIdAsync(id);
        if (eventObj == null) return NotFound();
        return Ok(eventObj);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEvents()
    {
        var events = await _eventService.GetAllEventsAsync();
        return Ok(events);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEvent(int id, [FromBody] Event eventObj)
    {
        if (id != eventObj.EventId) return BadRequest("Event ID mismatch.");
        await _eventService.UpdateEventAsync(eventObj);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(int id)
    {
        await _eventService.DeleteEventAsync(id);
        return NoContent();
    }
}
