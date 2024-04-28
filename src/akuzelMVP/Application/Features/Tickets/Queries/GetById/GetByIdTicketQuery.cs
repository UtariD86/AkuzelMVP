using Application.Features.Tickets.Constants;
using Application.Features.Tickets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Tickets.Constants.TicketsOperationClaims;

namespace Application.Features.Tickets.Queries.GetById;

public class GetByIdTicketQuery : IRequest<GetByIdTicketResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdTicketQueryHandler : IRequestHandler<GetByIdTicketQuery, GetByIdTicketResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITicketRepository _ticketRepository;
        private readonly TicketBusinessRules _ticketBusinessRules;

        public GetByIdTicketQueryHandler(IMapper mapper, ITicketRepository ticketRepository, TicketBusinessRules ticketBusinessRules)
        {
            _mapper = mapper;
            _ticketRepository = ticketRepository;
            _ticketBusinessRules = ticketBusinessRules;
        }

        public async Task<GetByIdTicketResponse> Handle(GetByIdTicketQuery request, CancellationToken cancellationToken)
        {
            Ticket? ticket = await _ticketRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _ticketBusinessRules.TicketShouldExistWhenSelected(ticket);

            GetByIdTicketResponse response = _mapper.Map<GetByIdTicketResponse>(ticket);
            return response;
        }
    }
}