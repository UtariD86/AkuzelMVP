using Application.Features.BankaHesaps.Constants;
using Application.Features.BankaHesaps.Constants;
using Application.Features.BankaHesaps.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.BankaHesaps.Constants.BankaHesapsOperationClaims;

namespace Application.Features.BankaHesaps.Commands.Delete;

public class DeleteBankaHesapCommand : IRequest<DeletedBankaHesapResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, BankaHesapsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBankaHesaps"];

    public class DeleteBankaHesapCommandHandler : IRequestHandler<DeleteBankaHesapCommand, DeletedBankaHesapResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBankaHesapRepository _bankaHesapRepository;
        private readonly BankaHesapBusinessRules _bankaHesapBusinessRules;

        public DeleteBankaHesapCommandHandler(IMapper mapper, IBankaHesapRepository bankaHesapRepository,
                                         BankaHesapBusinessRules bankaHesapBusinessRules)
        {
            _mapper = mapper;
            _bankaHesapRepository = bankaHesapRepository;
            _bankaHesapBusinessRules = bankaHesapBusinessRules;
        }

        public async Task<DeletedBankaHesapResponse> Handle(DeleteBankaHesapCommand request, CancellationToken cancellationToken)
        {
            BankaHesap? bankaHesap = await _bankaHesapRepository.GetAsync(predicate: bh => bh.Id == request.Id, cancellationToken: cancellationToken);
            await _bankaHesapBusinessRules.BankaHesapShouldExistWhenSelected(bankaHesap);

            await _bankaHesapRepository.DeleteAsync(bankaHesap!);

            DeletedBankaHesapResponse response = _mapper.Map<DeletedBankaHesapResponse>(bankaHesap);
            return response;
        }
    }
}