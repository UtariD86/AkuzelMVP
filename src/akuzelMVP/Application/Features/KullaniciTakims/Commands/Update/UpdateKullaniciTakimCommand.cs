using Application.Features.KullaniciTakims.Constants;
using Application.Features.KullaniciTakims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.KullaniciTakims.Constants.KullaniciTakimsOperationClaims;

namespace Application.Features.KullaniciTakims.Commands.Update;

public class UpdateKullaniciTakimCommand : IRequest<UpdatedKullaniciTakimResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required Guid UserId { get; set; }
    public required Guid TakimId { get; set; }
    public required bool Onay { get; set; }
    public required Guid DuzenleyenId { get; set; }

    public string[] Roles => [Admin, Write, KullaniciTakimsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetKullaniciTakims"];

    public class UpdateKullaniciTakimCommandHandler : IRequestHandler<UpdateKullaniciTakimCommand, UpdatedKullaniciTakimResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKullaniciTakimRepository _kullaniciTakimRepository;
        private readonly KullaniciTakimBusinessRules _kullaniciTakimBusinessRules;

        public UpdateKullaniciTakimCommandHandler(IMapper mapper, IKullaniciTakimRepository kullaniciTakimRepository,
                                         KullaniciTakimBusinessRules kullaniciTakimBusinessRules)
        {
            _mapper = mapper;
            _kullaniciTakimRepository = kullaniciTakimRepository;
            _kullaniciTakimBusinessRules = kullaniciTakimBusinessRules;
        }

        public async Task<UpdatedKullaniciTakimResponse> Handle(UpdateKullaniciTakimCommand request, CancellationToken cancellationToken)
        {
            KullaniciTakim? kullaniciTakim = await _kullaniciTakimRepository.GetAsync(predicate: kt => kt.Id == request.Id, cancellationToken: cancellationToken);
            await _kullaniciTakimBusinessRules.KullaniciTakimShouldExistWhenSelected(kullaniciTakim);
            kullaniciTakim = _mapper.Map(request, kullaniciTakim);

            await _kullaniciTakimRepository.UpdateAsync(kullaniciTakim!);

            UpdatedKullaniciTakimResponse response = _mapper.Map<UpdatedKullaniciTakimResponse>(kullaniciTakim);
            return response;
        }
    }
}