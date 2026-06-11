using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Domain.Entities
{
    public class Rol
    {
        [Key]
        public byte Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public bool Active { get; set; }
        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
