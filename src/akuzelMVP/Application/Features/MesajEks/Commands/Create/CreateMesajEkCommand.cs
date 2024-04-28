using Application.Features.MesajEks.Constants;
using Application.Features.MesajEks.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using Domain.Enums;
using static Application.Features.MesajEks.Constants.MesajEksOperationClaims;

namespace Application.Features.MesajEks.Commands.Create;

public class CreateMesajEkCommand : IRequest<CreatedMesajEkResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required bool BildirimMi { get; set; }
    public required Guid MesajId { get; set; }
    public required MedyaType EkType { get; set; }
    public required string Icerik { get; set; }

    public string[] Roles => [Admin, Write, MesajEksOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMesajEks"];

    public class CreateMesajEkCommandHandler : IRequestHandler<CreateMesajEkCommand, CreatedMesajEkResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMesajEkRepository _mesajEkRepository;
        private readonly MesajEkBusinessRules _mesajEkBusinessRules;

        public CreateMesajEkCommandHandler(IMapper mapper, IMesajEkRepository mesajEkRepository,
                                         MesajEkBusinessRules mesajEkBusinessRules)
        {
            _mapper = mapper;
            _mesajEkRepository = mesajEkRepository;
            _mesajEkBusinessRules = mesajEkBusinessRules;
        }

        public async Task<CreatedMesajEkResponse> Handle(CreateMesajEkCommand request, CancellationToken cancellationToken)
        {
            MesajEk mesajEk = _mapper.Map<MesajEk>(request);

            await _mesajEkRepository.AddAsync(mesajEk);

            CreatedMesajEkResponse response = _mapper.Map<CreatedMesajEkResponse>(mesajEk);
            return response;
        }
    }
}