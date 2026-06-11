using AutoMapper;
using Helpdesk.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Business.DTOs.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Ticket, TicketDTO>()
                .ForMember(dto => dto.User, config => config.MapFrom(ticket => ticket.User.DisplayName))
                .ForMember(dto => dto.CommentsCount, config => config.MapFrom(ticket => ticket.Comments.Count))
                .ForMember(dto => dto.Status, config => config.MapFrom(ticket => ticket.Status.Name))
                .ForMember(dto => dto.Priority, config => config.MapFrom(ticket => ticket.Priority.Name));

            CreateMap<CreateTicketDTO, Ticket>();
            CreateMap<UpdateTicketDTO, Ticket>();

            CreateMap<CreateCommentDTO, Comment>();
            CreateMap<Comment, CommentDTO>()
                .ForMember(dto => dto.CreatorName, config => config.MapFrom(comment => comment.CreatedBy));
        }
    }
}
