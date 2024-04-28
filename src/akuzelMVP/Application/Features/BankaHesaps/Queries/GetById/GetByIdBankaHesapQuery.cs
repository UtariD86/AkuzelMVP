using Application.Features.BankaHesaps.Constants;
using Application.Features.BankaHesaps.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BankaHesaps.Constants.BankaHesapsOperationClaims;

namespace Application.Features.BankaHesaps.Queries.GetById;

public class GetByIdBankaHesapQuery : IRequest<GetByIdBankaHesapResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdBankaHesapQueryHandler : IRequestHandler<GetByIdBankaHesapQuery, GetByIdBankaHesapResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBankaHesapRepository _bankaHesapRepository;
        private readonly BankaHesapBusinessRules _bankaHesapBusinessRules;

        public GetByIdBankaHesapQueryHandler(IMapper mapper, IBankaHesapRepository bankaHesapRepository, BankaHesapBusinessRules bankaHesapBusinessRules)
        {
            _mapper = mapper;
            _bankaHesapRepository = bankaHesapRepository;
            _bankaHesapBusinessRules = bankaHesapBusinessRules;
        }

        public async Task<GetByIdBankaHesapResponse> Handle(GetByIdBankaHesapQuery request, CancellationToken cancellationToken)
        {
            BankaHesap? bankaHesap = await _bankaHesapRepository.GetAsync(predicate: bh => bh.Id == request.Id, cancellationToken: cancellationToken);
            await _bankaHesapBusinessRules.BankaHesapShouldExistWhenSelected(bankaHesap);

            GetByIdBankaHesapResponse response = _mapper.Map<GetByIdBankaHesapResponse>(bankaHesap);
            return response;
        }
    }
}