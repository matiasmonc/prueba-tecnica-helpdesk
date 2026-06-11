using Helpdesk.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Business.Services
{
    public interface ITicketService
    {
        Task<PagedTicketsDTO> getPagedTickets(PagedTicketsReqDTO pagedTicketsReq);
        Task<TicketDTO> getTicketById(int idTicket);
        Task<TicketDTO> createTicket(CreateTicketDTO createTicketDTO);
        Task<TicketDTO?> updateTicket(int id, UpdateTicketDTO updateTicketDTO);
        Task<TicketDTO?> updateTicketState(int id, byte idStatus);
        Task<CommentDTO?> CreateComment(int idTicket, CreateCommentDTO createCommentDTO);
        Task<IEnumerable<CommentDTO>> getCommentsByIdTicket(int idTicket);
    }
}
