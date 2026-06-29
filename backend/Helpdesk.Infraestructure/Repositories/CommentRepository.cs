using Helpdesk.Domain.Entities;
using Helpdesk.Business.Interfaces;
using Helpdesk.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Infraestructure.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly AppDbContext context;

        public CommentRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Comment?> getCommentById(int idComment)
        {
            return await context.Comment
                .Include(t => t.User)
                .FirstOrDefaultAsync(c => c.Id == idComment);
        }

        public async Task<IEnumerable<Comment>> GetCommentsByTicket(int idTicket)
        {
            return await context.Comment
                .Include(c => c.User)
                .Where(c => c.IdTicket == idTicket)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
        }
    }
}
