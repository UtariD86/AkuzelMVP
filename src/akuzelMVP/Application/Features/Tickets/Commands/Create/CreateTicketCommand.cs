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

namespace Application.Features.Tickets.Commands.Create;

public class CreateTicketCommand : IRequest<CreatedTicketResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required Guid KullaniciId { get; set; }
    public required Guid DepartmanId { get; set; }
    public required Guid HizmetId { get; set; }
    public required bool Cevaplandı { get; set; }
    public required string Baslik { get; set; }
    public required string Aciklama { get; set; }

    public string[] Roles => [Admin, Write, TicketsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTickets"];

    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, CreatedTicketResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITicketRepository _ticketRepository;
        private readonly TicketBusinessRules _ticketBusinessRules;

        public CreateTicketCommandHandler(IMapper mapper, ITicketRepository ticketRepository,
                                         TicketBusinessRules ticketBusinessRules)
        {
            _mapper = mapper;
            _ticketRepository = ticketRepository;
            _ticketBusinessRules = ticketBusinessRules;
        }

        public async Task<CreatedTicketResponse> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            Ticket ticket = _mapper.Map<Ticket>(request);

            await _ticketRepository.AddAsync(ticket);

            CreatedTicketResponse response = _mapper.Map<CreatedTicketResponse>(ticket);
            return response;
        }
    }
}