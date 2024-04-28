using Application.Features.SistemGecmisis.Constants;
using Application.Features.SistemGecmisis.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using Domain.Enums;
using static Application.Features.SistemGecmisis.Constants.SistemGecmisisOperationClaims;

namespace Application.Features.SistemGecmisis.Commands.Create;

public class CreateSistemGecmisiCommand : IRequest<CreatedSistemGecmisiResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required LogType LogType { get; set; }
    public required Guid Id1 { get; set; }
    public Guid? Id2 { get; set; }
    public Guid? Id3 { get; set; }
    public required string Aciklama { get; set; }

    public string[] Roles => [Admin, Write, SistemGecmisisOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSistemGecmisis"];

    public class CreateSistemGecmisiCommandHandler : IRequestHandler<CreateSistemGecmisiCommand, CreatedSistemGecmisiResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISistemGecmisiRepository _sistemGecmisiRepository;
        private readonly SistemGecmisiBusinessRules _sistemGecmisiBusinessRules;

        public CreateSistemGecmisiCommandHandler(IMapper mapper, ISistemGecmisiRepository sistemGecmisiRepository,
                                         SistemGecmisiBusinessRules sistemGecmisiBusinessRules)
        {
            _mapper = mapper;
            _sistemGecmisiRepository = sistemGecmisiRepository;
            _sistemGecmisiBusinessRules = sistemGecmisiBusinessRules;
        }

        public async Task<CreatedSistemGecmisiResponse> Handle(CreateSistemGecmisiCommand request, CancellationToken cancellationToken)
        {
            SistemGecmisi sistemGecmisi = _mapper.Map<SistemGecmisi>(request);

            await _sistemGecmisiRepository.AddAsync(sistemGecmisi);

            CreatedSistemGecmisiResponse response = _mapper.Map<CreatedSistemGecmisiResponse>(sistemGecmisi);
            return response;
        }
    }
}