using ApiLayer.DTOs;
using AutoMapper;
using BusinessLogic.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly IMapper _mapper;

        public TicketsController(ITicketService ticketService, IMapper mapper)
        {
            _ticketService = ticketService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tickets = await _ticketService.GetAllTicketsAsync();
            var ticketDtos = _mapper.Map<IEnumerable<TicketDto>>(tickets);
            return Ok(ticketDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            if (ticket == null) return NotFound();
            var ticketDto = _mapper.Map<TicketDto>(ticket);
            return Ok(ticketDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TicketDto ticketDto)
        {
            var ticket = _mapper.Map<Ticket>(ticketDto);
            await _ticketService.AddTicketAsync(ticket);
            return CreatedAtAction(nameof(GetById), new { id = ticket.Id }, ticketDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TicketDto ticketDto)
        {
            if (id != ticketDto.Id) return BadRequest("ID mismatch.");
            var ticket = _mapper.Map<Ticket>(ticketDto);
            await _ticketService.UpdateTicketAsync(ticket);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _ticketService.DeleteTicketAsync(id);
            return NoContent();
        }
    }

}
