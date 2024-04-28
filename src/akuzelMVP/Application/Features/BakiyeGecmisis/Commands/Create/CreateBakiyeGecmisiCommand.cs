using Application.Features.BakiyeGecmisis.Constants;
using Application.Features.BakiyeGecmisis.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using Domain.Enums;
using static Application.Features.BakiyeGecmisis.Constants.BakiyeGecmisisOperationClaims;

namespace Application.Features.BakiyeGecmisis.Commands.Create;

public class CreateBakiyeGecmisiCommand : IRequest<CreatedBakiyeGecmisiResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required BakiyeLogType LogType { get; set; }
    public required Guid Id1 { get; set; }
    public Guid? Id2 { get; set; }
    public Guid? SiparisId { get; set; }
    public required double KomisyonOrani { get; set; }
    public required double Kazanc { get; set; }
    public required string Aciklama { get; set; }
    public required double BakiyeDegisimi { get; set; }
    public required bool Onay { get; set; }

    public string[] Roles => [Admin, Write, BakiyeGecmisisOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBakiyeGecmisis"];

    public class CreateBakiyeGecmisiCommandHandler : IRequestHandler<CreateBakiyeGecmisiCommand, CreatedBakiyeGecmisiResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBakiyeGecmisiRepository _bakiyeGecmisiRepository;
        private readonly BakiyeGecmisiBusinessRules _bakiyeGecmisiBusinessRules;

        public CreateBakiyeGecmisiCommandHandler(IMapper mapper, IBakiyeGecmisiRepository bakiyeGecmisiRepository,
                                         BakiyeGecmisiBusinessRules bakiyeGecmisiBusinessRules)
        {
            _mapper = mapper;
            _bakiyeGecmisiRepository = bakiyeGecmisiRepository;
            _bakiyeGecmisiBusinessRules = bakiyeGecmisiBusinessRules;
        }

        public async Task<CreatedBakiyeGecmisiResponse> Handle(CreateBakiyeGecmisiCommand request, CancellationToken cancellationToken)
        {
            BakiyeGecmisi bakiyeGecmisi = _mapper.Map<BakiyeGecmisi>(request);

            await _bakiyeGecmisiRepository.AddAsync(bakiyeGecmisi);

            CreatedBakiyeGecmisiResponse response = _mapper.Map<CreatedBakiyeGecmisiResponse>(bakiyeGecmisi);
            return response;
        }
    }
}