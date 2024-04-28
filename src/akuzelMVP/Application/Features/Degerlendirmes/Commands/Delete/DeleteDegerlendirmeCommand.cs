using Application.Features.Degerlendirmes.Constants;
using Application.Features.Degerlendirmes.Constants;
using Application.Features.Degerlendirmes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Degerlendirmes.Constants.DegerlendirmesOperationClaims;

namespace Application.Features.Degerlendirmes.Commands.Delete;

public class DeleteDegerlendirmeCommand : IRequest<DeletedDegerlendirmeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, DegerlendirmesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetDegerlendirmes"];

    public class DeleteDegerlendirmeCommandHandler : IRequestHandler<DeleteDegerlendirmeCommand, DeletedDegerlendirmeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDegerlendirmeRepository _degerlendirmeRepository;
        private readonly DegerlendirmeBusinessRules _degerlendirmeBusinessRules;

        public DeleteDegerlendirmeCommandHandler(IMapper mapper, IDegerlendirmeRepository degerlendirmeRepository,
                                         DegerlendirmeBusinessRules degerlendirmeBusinessRules)
        {
            _mapper = mapper;
            _degerlendirmeRepository = degerlendirmeRepository;
            _degerlendirmeBusinessRules = degerlendirmeBusinessRules;
        }

        public async Task<DeletedDegerlendirmeResponse> Handle(DeleteDegerlendirmeCommand request, CancellationToken cancellationToken)
        {
            Degerlendirme? degerlendirme = await _degerlendirmeRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _degerlendirmeBusinessRules.DegerlendirmeShouldExistWhenSelected(degerlendirme);

            await _degerlendirmeRepository.DeleteAsync(degerlendirme!);

            DeletedDegerlendirmeResponse response = _mapper.Map<DeletedDegerlendirmeResponse>(degerlendirme);
            return response;
        }
    }
}