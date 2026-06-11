using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Domain.Entities
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(120)]
        public string Title { get; set; } = string.Empty;
        [Required, StringLength(2000)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Guid CreatedBy { get; set; }
        [ForeignKey(nameof(CreatedBy))]
        public virtual User User { get; set; } = null!;

        [Required]
        public byte IdPriority { get; set; }
        [ForeignKey(nameof(IdPriority))]
        public virtual Priority Priority { get; set; } = null!;

        [Required]
        public byte IdStatus { get; set; }
        [ForeignKey(nameof(IdStatus))]
        public virtual Status Status { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
