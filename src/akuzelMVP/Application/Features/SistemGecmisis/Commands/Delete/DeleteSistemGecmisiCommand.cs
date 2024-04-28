using Application.Features.SistemGecmisis.Constants;
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
using static Application.Features.SistemGecmisis.Constants.SistemGecmisisOperationClaims;

namespace Application.Features.SistemGecmisis.Commands.Delete;

public class DeleteSistemGecmisiCommand : IRequest<DeletedSistemGecmisiResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, SistemGecmisisOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSistemGecmisis"];

    public class DeleteSistemGecmisiCommandHandler : IRequestHandler<DeleteSistemGecmisiCommand, DeletedSistemGecmisiResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISistemGecmisiRepository _sistemGecmisiRepository;
        private readonly SistemGecmisiBusinessRules _sistemGecmisiBusinessRules;

        public DeleteSistemGecmisiCommandHandler(IMapper mapper, ISistemGecmisiRepository sistemGecmisiRepository,
                                         SistemGecmisiBusinessRules sistemGecmisiBusinessRules)
        {
            _mapper = mapper;
            _sistemGecmisiRepository = sistemGecmisiRepository;
            _sistemGecmisiBusinessRules = sistemGecmisiBusinessRules;
        }

        public async Task<DeletedSistemGecmisiResponse> Handle(DeleteSistemGecmisiCommand request, CancellationToken cancellationToken)
        {
            SistemGecmisi? sistemGecmisi = await _sistemGecmisiRepository.GetAsync(predicate: sg => sg.Id == request.Id, cancellationToken: cancellationToken);
            await _sistemGecmisiBusinessRules.SistemGecmisiShouldExistWhenSelected(sistemGecmisi);

            await _sistemGecmisiRepository.DeleteAsync(sistemGecmisi!);

            DeletedSistemGecmisiResponse response = _mapper.Map<DeletedSistemGecmisiResponse>(sistemGecmisi);
            return response;
        }
    }
}