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
        /// <summary>
        /// Título del ticket (máx. 120 caracteres).
        /// </summary>
        [Required]
        [StringLength(120)]
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// Descripción detallada del ticket (máx. 2000 caracteres).
        /// </summary>
        [Required]
        [StringLength(2000)]
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Id de la prioridad.
        /// </summary>
        [Required]
        public byte IdPriority { get; set; }
        /// <summary>
        /// Id del estado inicial del ticket.
        /// </summary>
        [Required]
        public byte IdStatus { get; set; }
        /// <summary>
        /// Identificador del usuario que crea el ticket (GUID).
        /// </summary>
        [Required]
        public Guid CreatedBy { get; set; }
    }
}
