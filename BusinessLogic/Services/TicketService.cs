using BusinessLogic.Interfaces;
using DataLayer.Interfaces;
using DataLayer.Models;

namespace BusinessLogic.Services
{
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TicketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
            return await _unitOfWork.Tickets.GetAllAsync();
        }

        public async Task<Ticket> GetTicketByIdAsync(int id)
        {
            return await _unitOfWork.Tickets.GetByIdAsync(id);
        }

        public async Task AddTicketAsync(Ticket ticket)
        {
            await _unitOfWork.Tickets.AddAsync(ticket);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateTicketAsync(Ticket ticket)
        {
            await _unitOfWork.Tickets.UpdateAsync(ticket);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteTicketAsync(int id)
        {
            await _unitOfWork.Tickets.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }

}
