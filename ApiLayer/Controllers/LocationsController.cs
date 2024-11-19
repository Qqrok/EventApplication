using ApiLayer.DTOs;
using AutoMapper;
using BusinessLogic.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;

        public LocationsController(ILocationService locationService, IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var locations = await _locationService.GetAllLocationsAsync();
            var locationDtos = _mapper.Map<IEnumerable<LocationDto>>(locations);
            return Ok(locationDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var location = await _locationService.GetLocationByIdAsync(id);
            if (location == null) return NotFound();
            var locationDto = _mapper.Map<LocationDto>(location);
            return Ok(locationDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LocationDto locationDto)
        {
            var location = _mapper.Map<Location>(locationDto);
            await _locationService.AddLocationAsync(location);
            return CreatedAtAction(nameof(GetById), new { id = location.Id }, locationDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LocationDto locationDto)
        {
            if (id != locationDto.Id) return BadRequest("ID mismatch.");
            var location = _mapper.Map<Location>(locationDto);
            await _locationService.UpdateLocationAsync(location);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _locationService.DeleteLocationAsync(id);
            return NoContent();
        }
    }

}
