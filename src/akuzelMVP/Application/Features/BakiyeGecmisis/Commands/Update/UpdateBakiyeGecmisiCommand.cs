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

namespace Application.Features.BakiyeGecmisis.Commands.Update;

public class UpdateBakiyeGecmisiCommand : IRequest<UpdatedBakiyeGecmisiResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required BakiyeLogType LogType { get; set; }
    public required Guid Id1 { get; set; }
    public Guid? Id2 { get; set; }
    public Guid? SiparisId { get; set; }
    public required double KomisyonOrani { get; set; }
    public required double Kazanc { get; set; }
    public required string Aciklama { get; set; }
    public required double BakiyeDegisimi { get; set; }
    public required bool Onay { get; set; }

    public string[] Roles => [Admin, Write, BakiyeGecmisisOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBakiyeGecmisis"];

    public class UpdateBakiyeGecmisiCommandHandler : IRequestHandler<UpdateBakiyeGecmisiCommand, UpdatedBakiyeGecmisiResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBakiyeGecmisiRepository _bakiyeGecmisiRepository;
        private readonly BakiyeGecmisiBusinessRules _bakiyeGecmisiBusinessRules;

        public UpdateBakiyeGecmisiCommandHandler(IMapper mapper, IBakiyeGecmisiRepository bakiyeGecmisiRepository,
                                         BakiyeGecmisiBusinessRules bakiyeGecmisiBusinessRules)
        {
            _mapper = mapper;
            _bakiyeGecmisiRepository = bakiyeGecmisiRepository;
            _bakiyeGecmisiBusinessRules = bakiyeGecmisiBusinessRules;
        }

        public async Task<UpdatedBakiyeGecmisiResponse> Handle(UpdateBakiyeGecmisiCommand request, CancellationToken cancellationToken)
        {
            BakiyeGecmisi? bakiyeGecmisi = await _bakiyeGecmisiRepository.GetAsync(predicate: bg => bg.Id == request.Id, cancellationToken: cancellationToken);
            await _bakiyeGecmisiBusinessRules.BakiyeGecmisiShouldExistWhenSelected(bakiyeGecmisi);
            bakiyeGecmisi = _mapper.Map(request, bakiyeGecmisi);

            await _bakiyeGecmisiRepository.UpdateAsync(bakiyeGecmisi!);

            UpdatedBakiyeGecmisiResponse response = _mapper.Map<UpdatedBakiyeGecmisiResponse>(bakiyeGecmisi);
            return response;
        }
    }
}