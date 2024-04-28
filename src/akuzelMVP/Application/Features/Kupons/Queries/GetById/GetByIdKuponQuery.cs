using Application.Features.Kupons.Constants;
using Application.Features.Kupons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Kupons.Constants.KuponsOperationClaims;

namespace Application.Features.Kupons.Queries.GetById;

public class GetByIdKuponQuery : IRequest<GetByIdKuponResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdKuponQueryHandler : IRequestHandler<GetByIdKuponQuery, GetByIdKuponResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKuponRepository _kuponRepository;
        private readonly KuponBusinessRules _kuponBusinessRules;

        public GetByIdKuponQueryHandler(IMapper mapper, IKuponRepository kuponRepository, KuponBusinessRules kuponBusinessRules)
        {
            _mapper = mapper;
            _kuponRepository = kuponRepository;
            _kuponBusinessRules = kuponBusinessRules;
        }

        public async Task<GetByIdKuponResponse> Handle(GetByIdKuponQuery request, CancellationToken cancellationToken)
        {
            Kupon? kupon = await _kuponRepository.GetAsync(predicate: k => k.Id == request.Id, cancellationToken: cancellationToken);
            await _kuponBusinessRules.KuponShouldExistWhenSelected(kupon);

            GetByIdKuponResponse response = _mapper.Map<GetByIdKuponResponse>(kupon);
            return response;
        }
    }
}