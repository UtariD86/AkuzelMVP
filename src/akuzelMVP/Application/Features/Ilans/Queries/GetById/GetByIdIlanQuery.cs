using Application.Features.Ilans.Constants;
using Application.Features.Ilans.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Ilans.Constants.IlansOperationClaims;

namespace Application.Features.Ilans.Queries.GetById;

public class GetByIdIlanQuery : IRequest<GetByIdIlanResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdIlanQueryHandler : IRequestHandler<GetByIdIlanQuery, GetByIdIlanResponse>
    {
        private readonly IMapper _mapper;
        private readonly IIlanRepository _ilanRepository;
        private readonly IlanBusinessRules _ilanBusinessRules;

        public GetByIdIlanQueryHandler(IMapper mapper, IIlanRepository ilanRepository, IlanBusinessRules ilanBusinessRules)
        {
            _mapper = mapper;
            _ilanRepository = ilanRepository;
            _ilanBusinessRules = ilanBusinessRules;
        }

        public async Task<GetByIdIlanResponse> Handle(GetByIdIlanQuery request, CancellationToken cancellationToken)
        {
            Ilan? ilan = await _ilanRepository.GetAsync(predicate: i => i.Id == request.Id, cancellationToken: cancellationToken);
            await _ilanBusinessRules.IlanShouldExistWhenSelected(ilan);

            GetByIdIlanResponse response = _mapper.Map<GetByIdIlanResponse>(ilan);
            return response;
        }
    }
}