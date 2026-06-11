using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Business.DTOs
{
    public class UpdateTicketDTO
    {
        /// <summary>
        /// Nuevo título del ticket.
        /// </summary>
        [Required]
        [StringLength(120)]
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// Nueva descripción del ticket.
        /// </summary>
        [Required]
        [StringLength(2000)]
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Id de la prioridad.
        /// </summary>
        [Required]
        public byte IdPriority { get; set; }
    }
}
