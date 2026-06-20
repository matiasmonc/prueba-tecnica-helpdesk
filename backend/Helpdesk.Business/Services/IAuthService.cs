using Helpdesk.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Business.Services
{
    public interface IAuthService
    {
        Task CreateUserAsync(CreateUserDTO createUserDTO);
        Task<(UserDTO user, TokenResponseDTO token)> Login(LoginDTO loginDTO);
    }
}
