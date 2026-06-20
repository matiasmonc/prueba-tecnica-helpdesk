using Helpdesk.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Business.DTOs
{
    public class UserDTO
    {
        [Required, StringLength(500), EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, StringLength(100)]
        public string DisplayName { get; set; } = string.Empty;
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public string NameRol { get; set; }
    }
}
