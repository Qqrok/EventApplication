using ApiLayer.DTOs;
using AutoMapper;
using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public EventsController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _eventService.GetAllEventsAsync();
            var eventDtos = _mapper.Map<IEnumerable<EventDto>>(events);
            return Ok(eventDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var eventEntity = await _eventService.GetEventByIdAsync(id);
            if (eventEntity == null) return NotFound();
            var eventDto = _mapper.Map<EventDto>(eventEntity);
            return Ok(eventDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EventDto eventDto)
        {
            var eventEntity = _mapper.Map<Event>(eventDto);
            await _eventService.AddEventAsync(eventEntity);
            return CreatedAtAction(nameof(GetById), new { id = eventEntity.Id }, eventDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EventDto eventDto)
        {
            if (id != eventDto.Id) return BadRequest("ID mismatch.");
            var eventEntity = _mapper.Map<Event>(eventDto);
            await _eventService.UpdateEventAsync(eventEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _eventService.DeleteEventAsync(id);
            return NoContent();
        }
    }

}
