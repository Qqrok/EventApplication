using DataLayer.Extensions;
using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class EventRepository : IRepository<Event>
    {
        private readonly EventAppContext _context;

        public EventRepository(EventAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event> GetByIdAsync(int id)
        {
            return await _context.Events.FindAsync(id);
        }

        public async Task AddAsync(Event entity)
        {
            await _context.Events.AddAsync(entity);
        }

        public async Task UpdateAsync(Event entity)
        {
            _context.Events.Update(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var eventEntity = await _context.Events.FindAsync(id);
            if (eventEntity != null)
            {
                _context.Events.Remove(eventEntity);
            }
        }
    }

}
