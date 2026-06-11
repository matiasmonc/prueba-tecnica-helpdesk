using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Business.DTOs
{
    public class CreateTicketDTO
    {
        [Required]
        [StringLength(120)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [StringLength(2000)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public byte IdPriority { get; set; }
        [Required]
        public byte IdStatus { get; set; }
        [Required]
        public Guid CreatedBy { get; set; }
    }
}
