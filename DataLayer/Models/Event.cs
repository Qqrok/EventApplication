using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int LocationId { get; set; }

        public Location Location { get; set; }
        public ICollection<UserEvent> UserEvents { get; set; } = new List<UserEvent>();
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }

}
