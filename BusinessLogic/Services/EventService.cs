using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await _unitOfWork.Events.GetAllAsync();
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            return await _unitOfWork.Events.GetByIdAsync(id);
        }

        public async Task AddEventAsync(Event eventEntity)
        {
            await _unitOfWork.Events.AddAsync(eventEntity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateEventAsync(Event eventEntity)
        {
            await _unitOfWork.Events.UpdateAsync(eventEntity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteEventAsync(int id)
        {
            await _unitOfWork.Events.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }

}
