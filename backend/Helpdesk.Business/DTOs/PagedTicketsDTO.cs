using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Business.DTOs
{
    public class PagedTicketsDTO
    {
        /// <summary>
        /// Lista de tickets de la página actual.
        /// </summary>
        public IEnumerable<TicketDTO> Tickets { get; set; } = new HashSet<TicketDTO>();
        /// <summary>
        /// Total de filas filtradas.
        /// </summary>
        public int TotalFilteredRows { get; set; }
        /// <summary>
        /// Total de páginas.
        /// </summary>
        public int TotalPages { get; set; }
    }
}
