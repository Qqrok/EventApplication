using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Event> Events { get; }
        IRepository<User> Users { get; }
        IRepository<Location> Locations { get; }
        IRepository<Ticket> Tickets { get; }
        IUserEventRepository UserEvents { get; }
        Task<int> SaveChangesAsync();
    }

}
