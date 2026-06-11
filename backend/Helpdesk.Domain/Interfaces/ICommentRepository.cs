using Helpdesk.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Domain.Interfaces
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task<Comment?> getCommentById(int id);
        Task<IEnumerable<Comment>?> GetCommentsByTicket(int idTicket);
    }
}
