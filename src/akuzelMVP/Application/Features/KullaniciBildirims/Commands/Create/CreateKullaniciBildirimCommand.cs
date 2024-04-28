using Application.Features.KullaniciBildirims.Constants;
using Application.Features.KullaniciBildirims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.KullaniciBildirims.Constants.KullaniciBildirimsOperationClaims;

namespace Application.Features.KullaniciBildirims.Commands.Create;

public class CreateKullaniciBildirimCommand : IRequest<CreatedKullaniciBildirimResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required Guid KullaniciId { get; set; }
    public required Guid BildirimId { get; set; }
    public required bool Goruldu { get; set; }

    public string[] Roles => [Admin, Write, KullaniciBildirimsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetKullaniciBildirims"];

    public class CreateKullaniciBildirimCommandHandler : IRequestHandler<CreateKullaniciBildirimCommand, CreatedKullaniciBildirimResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKullaniciBildirimRepository _kullaniciBildirimRepository;
        private readonly KullaniciBildirimBusinessRules _kullaniciBildirimBusinessRules;

        public CreateKullaniciBildirimCommandHandler(IMapper mapper, IKullaniciBildirimRepository kullaniciBildirimRepository,
                                         KullaniciBildirimBusinessRules kullaniciBildirimBusinessRules)
        {
            _mapper = mapper;
            _kullaniciBildirimRepository = kullaniciBildirimRepository;
            _kullaniciBildirimBusinessRules = kullaniciBildirimBusinessRules;
        }

        public async Task<CreatedKullaniciBildirimResponse> Handle(CreateKullaniciBildirimCommand request, CancellationToken cancellationToken)
        {
            KullaniciBildirim kullaniciBildirim = _mapper.Map<KullaniciBildirim>(request);

            await _kullaniciBildirimRepository.AddAsync(kullaniciBildirim);

            CreatedKullaniciBildirimResponse response = _mapper.Map<CreatedKullaniciBildirimResponse>(kullaniciBildirim);
            return response;
        }
    }
}