using DataLayer.Extensions;
using DataLayer.Interfaces;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EventAppContext _context;
        private IRepository<Event> _events;
        private IRepository<User> _users;
        private IRepository<Location> _locations;
        private IRepository<Ticket> _tickets;
        private IUserEventRepository _userEvents;

        public UnitOfWork(EventAppContext context)
        {
            _context = context;
        }

        public IRepository<Event> Events => _events ??= new EventRepository(_context);
        public IRepository<User> Users => _users ??= new UserRepository(_context);
        public IRepository<Location> Locations => _locations ??= new LocationRepository(_context);
        public IRepository<Ticket> Tickets => _tickets ??= new TicketRepository(_context);
        public IUserEventRepository UserEvents => _userEvents ??= new UserEventRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }



}
