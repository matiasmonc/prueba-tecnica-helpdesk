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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDbContext context;

        public UserRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<User?> getUserByEmail(string email)
        {
            return await context.User
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(u => u.Email == email);
        }
}
}
