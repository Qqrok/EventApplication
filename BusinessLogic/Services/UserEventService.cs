using BusinessLogic.Interfaces;
using DataLayer.Interfaces;
using DataLayer.Models;

namespace BusinessLogic.Services
{
    public class UserEventService : IUserEventService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserEventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task RegisterUserForEventAsync(int userId, int eventId)
        {
            await _unitOfWork.UserEvents.AddUserEventAsync(userId, eventId);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UnregisterUserFromEventAsync(int userId, int eventId)
        {
            await _unitOfWork.UserEvents.RemoveUserEventAsync(userId, eventId);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserEvent>> GetUserEventsAsync(int userId)
        {
            return await _unitOfWork.UserEvents.GetUserEventsAsync(userId);
        }
    }

}
