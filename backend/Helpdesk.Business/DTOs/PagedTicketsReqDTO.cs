using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Business.DTOs
{
    public class PagedTicketsReqDTO
    {
        /// <summary>
        /// Filtro por nombre del estado.
        /// </summary>
        public string? Status { get; set; } = string.Empty;
        /// <summary>
        /// Filtro por prioridad.
        /// </summary>
        public string? Priority { get; set; } = string.Empty;
        /// <summary>
        /// Texto de búsqueda libre.
        /// </summary>
        public string? Q { get; set; } = string.Empty;
        /// <summary>
        /// Página solicitada (1-index).
        /// </summary>
        public int Page { get; set; } = 1;
        /// <summary>
        /// Tamaño de página.
        /// </summary>
        public int PageSize { get; set; } = 5;
    }
}
