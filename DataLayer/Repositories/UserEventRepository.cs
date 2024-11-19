using DataLayer.Extensions;
using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class UserEventRepository : IUserEventRepository
    {
        private readonly EventAppContext _context;

        public UserEventRepository(EventAppContext context)
        {
            _context = context;
        }

        public async Task AddUserEventAsync(int userId, int eventId)
        {
            var userEvent = new UserEvent { UserId = userId, EventId = eventId };
            await _context.UserEvents.AddAsync(userEvent);
        }

        public async Task RemoveUserEventAsync(int userId, int eventId)
        {
            var userEvent = await _context.UserEvents
                .FirstOrDefaultAsync(ue => ue.UserId == userId && ue.EventId == eventId);

            if (userEvent != null)
            {
                _context.UserEvents.Remove(userEvent);
            }
        }

        public async Task<IEnumerable<UserEvent>> GetUserEventsAsync(int userId)
        {
            return await _context.UserEvents
                .Where(ue => ue.UserId == userId)
                .ToListAsync();
        }
    }

}
