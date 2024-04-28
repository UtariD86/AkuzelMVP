using Application.Features.Tickets.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Tickets.Constants.TicketsOperationClaims;

namespace Application.Features.Tickets.Queries.GetList;

public class GetListTicketQuery : IRequest<GetListResponse<GetListTicketListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListTickets({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetTickets";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListTicketQueryHandler : IRequestHandler<GetListTicketQuery, GetListResponse<GetListTicketListItemDto>>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public GetListTicketQueryHandler(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTicketListItemDto>> Handle(GetListTicketQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Ticket> tickets = await _ticketRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTicketListItemDto> response = _mapper.Map<GetListResponse<GetListTicketListItemDto>>(tickets);
            return response;
        }
    }
}