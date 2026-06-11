using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Business.DTOs
{
    public class CreateCommentDTO
    {
        [Required]
        [StringLength(1000)]
        public string Text { get; set; } = string.Empty;

        [Required]
        public Guid CreatedBy { get; set; }
    }
}
