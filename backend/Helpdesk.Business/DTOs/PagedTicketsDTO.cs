using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Business.DTOs
{
    public class PagedTicketsDTO
    {
        public IEnumerable<TicketDTO> Tickets { get; set; } = new HashSet<TicketDTO>();
        public int TotalFilteredRows { get; set; }
        public int TotalPages { get; set; }
    }
}
