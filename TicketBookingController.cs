using EventTicketingManagement.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TicketBookingsController : ControllerBase
{
    private readonly ITicketBookingService _ticketBookingService;

    public TicketBookingsController(ITicketBookingService ticketBookingService)
    {
        _ticketBookingService = ticketBookingService;
    }

    [HttpPost]
    public async Task<IActionResult> BookTicket([FromBody] TicketBooking booking)
    {
        var createdBooking = await _ticketBookingService.BookTicketAsync(booking);
        return CreatedAtAction(nameof(GetBookingById), new { id = createdBooking.BookingId }, createdBooking);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookingById(int id)
    {
        var booking = await _ticketBookingService.GetBookingByIdAsync(id);
        if (booking == null) return NotFound();
        return Ok(booking);
    }

    [HttpGet]
    

    [HttpDelete("{id}")]
    public async Task<IActionResult> CancelBooking(int id)
    {
        await _ticketBookingService.CancelBookingAsync(id);
        return NoContent();
    }
}
