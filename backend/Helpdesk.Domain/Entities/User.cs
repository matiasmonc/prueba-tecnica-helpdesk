using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required, StringLength(500)]
        public string Email { get; set; } = string.Empty;
        [Required, StringLength(255)]
        public string Password { get; set; } = string.Empty;
        [Required, StringLength(100)]
        public string DisplayName { get; set; } = string.Empty;
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public byte IdRol {  get; set; }
        [ForeignKey(nameof(IdRol))]
        public virtual Rol Rol { get; set; } = null!;

        public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}
