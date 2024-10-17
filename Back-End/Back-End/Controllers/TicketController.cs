using Back_End.Data;
using Back_End.Dtos.Ticket;
using Back_End.Helpers;
using Back_End.Interfaces;
using Back_End.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : Controller
    {
        private readonly ITicketRepository _repository;
        private readonly ApplicationDBContext _context;


        public TicketController(ITicketRepository repository, ApplicationDBContext context)
        {
            _repository = repository;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTickets([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tickets = await _repository.GetAllTickets(query);
            var ticketsDto = tickets.Select(t => t.ToDto());
            return Ok(ticketsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTicketById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ticket = await _repository.GetTicketById(id);

            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket.ToDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(TicketCreateDto ticketDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ticket = ticketDto.ToModel();

            await _repository.CreateTicket(ticket);
            await _repository.SaveChangesAsync();   
            return CreatedAtAction(nameof(GetTicketById), new { id = ticket.Ticket_ID }, ticket.ToDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateTicket([FromRoute] int id, [FromBody] TicketUpdateDto ticketDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ticket = await _repository.GetTicketById(id);

            if (ticket == null)
            {
                return NotFound();
            }

            ticket.Description = ticketDto.Description;
            ticket.Status = ticketDto.Status;

            await _repository.UpdateTicket(ticket);
            await _repository.SaveChangesAsync();
            var newTicket = await _repository.GetTicketById(id);
            return Ok(newTicket?.ToDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTicket([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var ticket = await _repository.GetTicketById(id);
            if (ticket == null)
            {
                return NotFound();
            }
            await _repository.DeleteTicket(ticket);
            await _repository.SaveChangesAsync();
            return NoContent();
        }
    }
}
