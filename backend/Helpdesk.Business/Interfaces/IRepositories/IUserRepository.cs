using Helpdesk.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Business.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> getUserByEmail(string email);
    }
}
