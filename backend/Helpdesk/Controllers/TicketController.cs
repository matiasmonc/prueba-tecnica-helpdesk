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

        [HttpGet]
        public async Task<IActionResult> GET([FromQuery] PagedTicketsReqDTO PagedTicketsReqDTO)
        {
            var pagedTickets = await ticketService.getPagedTickets(PagedTicketsReqDTO);
            return Ok(pagedTickets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GET([FromRoute] int idticket)
        {
            var ticket = await ticketService.getTicketById(idticket);
            return Ok(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> POST([FromBody] CreateTicketDTO createTicketDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ticket = await ticketService.createTicket(createTicketDTO);
            return Ok(ticket);
        }

        [HttpPut("{id}")]
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

        [HttpPatch("{id}/status")]
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

        [HttpPost("{id}/comments")]
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

        [HttpGet("{id}/comments")]
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
