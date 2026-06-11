using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Business.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public int IdTicket { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string CreatorName { get; set; } = string.Empty;
    }
}
