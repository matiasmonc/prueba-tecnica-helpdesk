using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Business.DTOs
{
    public class CommentDTO
    {
        /// <summary>
        /// Identificador del comentario.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Identificador del ticket asociado.
        /// </summary>
        public int IdTicket { get; set; }
        /// <summary>
        /// Texto del comentario.
        /// </summary>
        public string Text { get; set; } = string.Empty;
        /// <summary>
        /// Fecha de creación del comentario.
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Nombre del creador del comentario.
        /// </summary>
        public string CreatorName { get; set; } = string.Empty;
    }
}
