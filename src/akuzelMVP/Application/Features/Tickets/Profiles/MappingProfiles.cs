using Application.Features.Tickets.Commands.Create;
using Application.Features.Tickets.Commands.Delete;
using Application.Features.Tickets.Commands.Update;
using Application.Features.Tickets.Queries.GetById;
using Application.Features.Tickets.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Tickets.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateTicketCommand, Ticket>();
        CreateMap<Ticket, CreatedTicketResponse>();

        CreateMap<UpdateTicketCommand, Ticket>();
        CreateMap<Ticket, UpdatedTicketResponse>();

        CreateMap<DeleteTicketCommand, Ticket>();
        CreateMap<Ticket, DeletedTicketResponse>();

        CreateMap<Ticket, GetByIdTicketResponse>();

        CreateMap<Ticket, GetListTicketListItemDto>();
        CreateMap<IPaginate<Ticket>, GetListResponse<GetListTicketListItemDto>>();
    }
}