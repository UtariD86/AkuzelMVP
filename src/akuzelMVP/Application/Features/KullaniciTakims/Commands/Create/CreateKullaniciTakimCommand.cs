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

namespace Application.Features.KullaniciTakims.Commands.Create;

public class CreateKullaniciTakimCommand : IRequest<CreatedKullaniciTakimResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required Guid UserId { get; set; }
    public required Guid TakimId { get; set; }
    public required bool Onay { get; set; }
    public required Guid DuzenleyenId { get; set; }

    public string[] Roles => [Admin, Write, KullaniciTakimsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetKullaniciTakims"];

    public class CreateKullaniciTakimCommandHandler : IRequestHandler<CreateKullaniciTakimCommand, CreatedKullaniciTakimResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKullaniciTakimRepository _kullaniciTakimRepository;
        private readonly KullaniciTakimBusinessRules _kullaniciTakimBusinessRules;

        public CreateKullaniciTakimCommandHandler(IMapper mapper, IKullaniciTakimRepository kullaniciTakimRepository,
                                         KullaniciTakimBusinessRules kullaniciTakimBusinessRules)
        {
            _mapper = mapper;
            _kullaniciTakimRepository = kullaniciTakimRepository;
            _kullaniciTakimBusinessRules = kullaniciTakimBusinessRules;
        }

        public async Task<CreatedKullaniciTakimResponse> Handle(CreateKullaniciTakimCommand request, CancellationToken cancellationToken)
        {
            KullaniciTakim kullaniciTakim = _mapper.Map<KullaniciTakim>(request);

            await _kullaniciTakimRepository.AddAsync(kullaniciTakim);

            CreatedKullaniciTakimResponse response = _mapper.Map<CreatedKullaniciTakimResponse>(kullaniciTakim);
            return response;
        }
    }
}