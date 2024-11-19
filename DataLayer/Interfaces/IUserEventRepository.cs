using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IUserEventRepository
    {
        Task AddUserEventAsync(int userId, int eventId);
        Task RemoveUserEventAsync(int userId, int eventId);
        Task<IEnumerable<UserEvent>> GetUserEventsAsync(int userId);
    }

}
