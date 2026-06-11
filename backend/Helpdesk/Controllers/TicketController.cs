using Helpdesk.Business.DTOs;
using Helpdesk.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Helpdesk.Controllers
{
    [ApiController]
    [Route("api/tickets")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService ticketService;

        public TicketController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        /// <summary>
        /// Obtiene tickets paginados con filtros opcionales (status, priority y búsqueda Q).
        /// </summary>
        /// <param name="PagedTicketsReqDTO">Parámetros de paginación y filtros.</param>
        /// <returns>PagedTicketsDTO con la lista de tickets y metadatos de paginación.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedTicketsDTO), 200)]
        public async Task<IActionResult> GET([FromQuery] PagedTicketsReqDTO PagedTicketsReqDTO)
        {
            var pagedTickets = await ticketService.getPagedTickets(PagedTicketsReqDTO);
            return Ok(pagedTickets);
        }

        /// <summary>
        /// Obtiene un ticket por su Id.
        /// </summary>
        /// <param name="idticket">Id del ticket.</param>
        /// <returns>TicketDTO con la información detallada del ticket.</returns>
        [HttpGet("{idticket}")]
        [ProducesResponseType(typeof(TicketDTO), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GET([FromRoute] int idticket)
        {
            var ticket = await ticketService.getTicketById(idticket);
            return Ok(ticket);
        }

        /// <summary>
        /// Crea un nuevo ticket.
        /// </summary>
        /// <param name="createTicketDTO">Datos necesarios para crear el ticket.</param>
        /// <returns>TicketDTO con el ticket creado.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(TicketDTO), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> POST([FromBody] CreateTicketDTO createTicketDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ticket = await ticketService.createTicket(createTicketDTO);
            return Ok(ticket);
        }

        /// <summary>
        /// Actualiza un ticket existente.
        /// </summary>
        /// <param name="idticket">Id del ticket a actualizar.</param>
        /// <param name="updateTicketDTO">Datos a actualizar.</param>
        /// <returns>TicketDTO actualizado o 404 si no existe.</returns>
        [HttpPut("{idticket}")]
        [ProducesResponseType(typeof(TicketDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PUT([FromRoute] int idticket, [FromBody] UpdateTicketDTO updateTicketDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedTicket = await ticketService.updateTicket(idticket, updateTicketDTO);

            if (updatedTicket == null) return NotFound(new { Mensaje = $"El ticket con ID {idticket} no existe." });

            return Ok(updatedTicket);
        }

        /// <summary>
        /// Actualiza el estado de un ticket.
        /// </summary>
        /// <param name="idTicket">Id del ticket.</param>
        /// <param name="idStatus">Id del nuevo estado (byte).</param>
        /// <returns>TicketDTO con estado actualizado o 404 si no existe.</returns>
        [HttpPatch("{idTicket}/status")]
        [ProducesResponseType(typeof(TicketDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PATCH([FromRoute] int idTicket, [FromBody] byte idStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedTicket = await ticketService.updateTicketState(idTicket, idStatus);

            if (updatedTicket == null) return NotFound(new { Mensaje = $"No se encontró el ticket con ID {idTicket}." });

            return Ok(updatedTicket);
        }

        /// <summary>
        /// Crea un comentario asociado a un ticket.
        /// </summary>
        /// <param name="id">Id del ticket.</param>
        /// <param name="createCommentDTO">Datos del comentario.</param>
        /// <returns>CommentDTO creado o 404 si el ticket no existe.</returns>
        [HttpPost("{id}/comments")]
        [ProducesResponseType(typeof(CommentDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> CreateComment([FromRoute]int id, [FromBody] CreateCommentDTO createCommentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdComment = await ticketService.CreateComment(id, createCommentDTO);

            if (createdComment == null)
            {
                return NotFound(new { Mensaje = $"No se puede agregar el comentario porque el ticket con ID {id} no existe." });
            }

            return Ok(createdComment);
        }

        /// <summary>
        /// Obtiene comentarios asociados a un ticket.
        /// </summary>
        /// <param name="id">Id del ticket.</param>
        /// <returns>Lista de CommentDTO o 404 si el ticket no existe.</returns>
        [HttpGet("{id}/comments")]
        [ProducesResponseType(typeof(IEnumerable<CommentDTO>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetComments(int id)
        {
            var commentsDto = await ticketService.getCommentsByIdTicket(id);

            if (commentsDto == null)
            {
                return NotFound(new { Mensaje = $"No se pueden obtener comentarios porque el ticket con ID {id} no existe." });
            }

            return Ok(commentsDto);
        }
    }
}
