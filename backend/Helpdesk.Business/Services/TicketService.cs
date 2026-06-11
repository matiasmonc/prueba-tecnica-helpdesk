using AutoMapper;
using Helpdesk.Business.DTOs;
using Helpdesk.Domain.Entities;
using Helpdesk.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Business.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository ticketRepository;
        private readonly ICommentRepository commentRepository;
        private readonly IMapper mapper;

        public TicketService(ITicketRepository ticketRepository, IMapper mapper, ICommentRepository commentRepository)
        {
            this.ticketRepository = ticketRepository;
            this.commentRepository = commentRepository;
            this.mapper = mapper;
        }

        public async Task<PagedTicketsDTO> getPagedTickets(PagedTicketsReqDTO pagedTicketsReq)
        {
            PagedTicketsDTO pagedTicketsDTO = new();

            var tickets = await ticketRepository.getPagedTickets(pagedTicketsReq.Status, pagedTicketsReq.Priority, pagedTicketsReq.Q, pagedTicketsReq.Page, pagedTicketsReq.PageSize);
            pagedTicketsDTO.Tickets = mapper.Map<IEnumerable<TicketDTO>>(tickets.Items);
            pagedTicketsDTO.TotalFilteredRows = tickets.CountItems;
            pagedTicketsDTO.TotalPages = 1;

            return pagedTicketsDTO;
        }

        public async Task<TicketDTO> getTicketById(int idTicket)
        {
            var ticket = await ticketRepository.getTicketById(idTicket);
            TicketDTO ticketDTO = mapper.Map<TicketDTO>(ticket);

            return ticketDTO;
        }

        public async Task<TicketDTO> createTicket(CreateTicketDTO createTicketDTO)
        {
            var ticket = mapper.Map<Ticket>(createTicketDTO);

            ticket.CreatedAt = DateTime.Now;
            ticket.UpdatedAt = null;

            await ticketRepository.InsertAsync(ticket);
            await ticketRepository.SaveAsync(); 

            var newTicket = await ticketRepository.getTicketById(ticket.Id);

            TicketDTO ticketDTO = mapper.Map<TicketDTO>(newTicket);

            return ticketDTO;
        }

        public async Task<TicketDTO?> updateTicket(int id, UpdateTicketDTO updateTicketDTO)
        {
            var ticket = await ticketRepository.getTicketById(id);

            if (ticket == null) return null;
            mapper.Map(updateTicketDTO, ticket);
            ticket.UpdatedAt = DateTime.Now;

            await ticketRepository.UpdateAsync(ticket);
            await ticketRepository.SaveAsync();

            TicketDTO ticketDTO = mapper.Map<TicketDTO>(ticket);

            return ticketDTO;
        }

        public async Task<TicketDTO?> updateTicketState(int id, byte idStatus)
        {
            var ticket = await ticketRepository.getTicketById(id);

            if (ticket == null) return null;

            ticket.IdStatus = idStatus;
            ticket.UpdatedAt = DateTime.Now;

            await ticketRepository.UpdateAsync(ticket);
            await ticketRepository.SaveAsync();

            TicketDTO ticketDTO = mapper.Map<TicketDTO>(ticket);

            return ticketDTO;
        }

        public async Task<CommentDTO?> CreateComment(int idTicket, CreateCommentDTO createCommentDTO)
        {
            var ticketExists = await ticketRepository.GetByIdAsync(idTicket);

            if (ticketExists == null) return null;

            var comment = mapper.Map<Comment>(createCommentDTO);

            comment.IdTicket = idTicket;
            comment.CreatedAt = DateTime.Now;

            await commentRepository.InsertAsync(comment);
            await commentRepository.SaveAsync();

            var commentsTicket = await commentRepository.getCommentById(comment.Id);

            CommentDTO commentsDTO = mapper.Map<CommentDTO>(commentsTicket);

            return commentsDTO;
        }

        public async Task<IEnumerable<CommentDTO>?> getCommentsByIdTicket(int idTicket)
        {
            var ticketExists = await ticketRepository.GetByIdAsync(idTicket);
            if (ticketExists == null) return null;

            var comments = await commentRepository.GetCommentsByTicket(idTicket);
            IEnumerable<CommentDTO> commentsDTO = mapper.Map<IEnumerable<CommentDTO>>(comments);

            return commentsDTO;
        }
    }
}
