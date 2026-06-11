using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Domain.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdTicket { get; set; }
        [Required, StringLength(1000)]
        public string Text { get; set; } = string.Empty;
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public Guid CreatedBy { get; set; }

        [ForeignKey(nameof(IdTicket))]
        public virtual Ticket Ticket { get; set; } = null!;
        [ForeignKey(nameof(CreatedBy))]
        public virtual User User { get; set; } = null!;
    }
}
