using Helpdesk.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Business.DTOs
{
    public class TicketDTO
    {
        /// <summary>
        /// Identificador del ticket.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Título del ticket.
        /// </summary>
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// Descripción del ticket.
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Fecha de creación.
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Nombre del usuario creador.
        /// </summary>
        public string User { get; set; } = string.Empty;
        /// <summary>
        /// Cantidad de comentarios asociados.
        /// </summary>
        public int CommentsCount { get; set; }
        /// <summary>
        /// Nombre del estado.
        /// </summary>
        public string Status { get; set; } = string.Empty;
        /// <summary>
        /// Nombre de la prioridad.
        /// </summary>
        public string Priority { get; set; } = string.Empty;
    }
}
