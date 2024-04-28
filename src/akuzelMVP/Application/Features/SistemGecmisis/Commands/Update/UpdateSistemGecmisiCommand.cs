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

namespace Application.Features.SistemGecmisis.Commands.Update;

public class UpdateSistemGecmisiCommand : IRequest<UpdatedSistemGecmisiResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required LogType LogType { get; set; }
    public required Guid Id1 { get; set; }
    public Guid? Id2 { get; set; }
    public Guid? Id3 { get; set; }
    public required string Aciklama { get; set; }

    public string[] Roles => [Admin, Write, SistemGecmisisOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSistemGecmisis"];

    public class UpdateSistemGecmisiCommandHandler : IRequestHandler<UpdateSistemGecmisiCommand, UpdatedSistemGecmisiResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISistemGecmisiRepository _sistemGecmisiRepository;
        private readonly SistemGecmisiBusinessRules _sistemGecmisiBusinessRules;

        public UpdateSistemGecmisiCommandHandler(IMapper mapper, ISistemGecmisiRepository sistemGecmisiRepository,
                                         SistemGecmisiBusinessRules sistemGecmisiBusinessRules)
        {
            _mapper = mapper;
            _sistemGecmisiRepository = sistemGecmisiRepository;
            _sistemGecmisiBusinessRules = sistemGecmisiBusinessRules;
        }

        public async Task<UpdatedSistemGecmisiResponse> Handle(UpdateSistemGecmisiCommand request, CancellationToken cancellationToken)
        {
            SistemGecmisi? sistemGecmisi = await _sistemGecmisiRepository.GetAsync(predicate: sg => sg.Id == request.Id, cancellationToken: cancellationToken);
            await _sistemGecmisiBusinessRules.SistemGecmisiShouldExistWhenSelected(sistemGecmisi);
            sistemGecmisi = _mapper.Map(request, sistemGecmisi);

            await _sistemGecmisiRepository.UpdateAsync(sistemGecmisi!);

            UpdatedSistemGecmisiResponse response = _mapper.Map<UpdatedSistemGecmisiResponse>(sistemGecmisi);
            return response;
        }
    }
}