using Helpdesk.Domain.Entities;
using Helpdesk.Domain.Interfaces;
using Helpdesk.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Infraestructure.Repositories
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        private readonly AppDbContext context;

        public TicketRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<(IEnumerable<Ticket> Items, int CountItems)> getPagedTickets(string status, string priority, string q, int page, int pageSize)
        {
            var query = context.Ticket
            .Include(t => t.User)
            .Include(t => t.Status)
            .Include(t => t.Priority)
            .Include(t => t.Comments) 
            .AsQueryable();

            if (!string.IsNullOrWhiteSpace(status))
            {
                query = query.Where(t => t.Status.Name == status);
            }

            if (!string.IsNullOrWhiteSpace(priority))
            {
                query = query.Where(t => t.Priority.Name == priority);
            }

            if (!string.IsNullOrWhiteSpace(q))
            {
                var searchText = $"%{q}%";
                query = query.Where(t =>
                    EF.Functions.Like(t.Title, searchText) || EF.Functions.Like(t.Description, searchText));
            }

            int totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(t => t.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<Ticket?> getTicketById(int id)
        {
            return await context.Ticket
                .Include(t => t.User)
                .Include(t => t.Status)
                .Include(t => t.Priority)
                .Include(t => t.Comments)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
