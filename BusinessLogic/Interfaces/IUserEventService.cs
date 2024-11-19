using DataLayer.Models;

namespace BusinessLogic.Interfaces
{
    public interface IUserEventService
    {
        Task RegisterUserForEventAsync(int userId, int eventId);
        Task UnregisterUserFromEventAsync(int userId, int eventId);
        Task<IEnumerable<UserEvent>> GetUserEventsAsync(int userId);
    }

}
