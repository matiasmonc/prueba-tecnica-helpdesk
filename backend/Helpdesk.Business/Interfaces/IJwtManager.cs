using Helpdesk.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Business.Interfaces
{
    public interface IJwtManager
    {
        TokenResponseDTO GenerateToken(string email, byte idRol);
    }
}
