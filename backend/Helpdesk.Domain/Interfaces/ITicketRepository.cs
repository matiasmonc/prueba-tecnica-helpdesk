using Helpdesk.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Domain.Interfaces
{
    public interface ITicketRepository : IGenericRepository<Ticket>
    {
        Task<(IEnumerable<Ticket> Items, int CountItems)> getPagedTickets(string status, string priority, string q, int page, int pageSize);
        Task<Ticket?> getTicketById(int id);
    }
}
