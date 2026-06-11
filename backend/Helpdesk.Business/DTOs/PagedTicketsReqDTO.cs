using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Business.DTOs
{
    public class PagedTicketsReqDTO
    {
        public string? Status { get; set; } = string.Empty;
        public string? Priority { get; set; } = string.Empty;
        public string? Q { get; set; } = string.Empty;
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }
}
