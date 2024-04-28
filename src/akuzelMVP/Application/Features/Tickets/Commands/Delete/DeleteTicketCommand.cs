using Application.Features.Tickets.Constants;
using Application.Features.Tickets.Constants;
using Application.Features.Tickets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Tickets.Constants.TicketsOperationClaims;

namespace Application.Features.Tickets.Commands.Delete;

public class DeleteTicketCommand : IRequest<DeletedTicketResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, TicketsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTickets"];

    public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand, DeletedTicketResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITicketRepository _ticketRepository;
        private readonly TicketBusinessRules _ticketBusinessRules;

        public DeleteTicketCommandHandler(IMapper mapper, ITicketRepository ticketRepository,
                                         TicketBusinessRules ticketBusinessRules)
        {
            _mapper = mapper;
            _ticketRepository = ticketRepository;
            _ticketBusinessRules = ticketBusinessRules;
        }

        public async Task<DeletedTicketResponse> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
        {
            Ticket? ticket = await _ticketRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _ticketBusinessRules.TicketShouldExistWhenSelected(ticket);

            await _ticketRepository.DeleteAsync(ticket!);

            DeletedTicketResponse response = _mapper.Map<DeletedTicketResponse>(ticket);
            return response;
        }
    }
}