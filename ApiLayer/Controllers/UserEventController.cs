using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserEventController : ControllerBase
    {
        private readonly IUserEventService _userEventService;

        public UserEventController(IUserEventService userEventService)
        {
            _userEventService = userEventService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUserForEvent(int userId, int eventId)
        {
            await _userEventService.RegisterUserForEventAsync(userId, eventId);
            return Ok($"User {userId} registered for event {eventId}.");
        }

        [HttpDelete("unregister")]
        public async Task<IActionResult> UnregisterUserFromEvent(int userId, int eventId)
        {
            await _userEventService.UnregisterUserFromEventAsync(userId, eventId);
            return Ok($"User {userId} unregistered from event {eventId}.");
        }
    }

}
