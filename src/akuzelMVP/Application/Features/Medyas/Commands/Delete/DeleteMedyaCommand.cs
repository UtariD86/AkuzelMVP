using Application.Features.Medyas.Constants;
using Application.Features.Medyas.Constants;
using Application.Features.Medyas.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Medyas.Constants.MedyasOperationClaims;

namespace Application.Features.Medyas.Commands.Delete;

public class DeleteMedyaCommand : IRequest<DeletedMedyaResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, MedyasOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMedyas"];

    public class DeleteMedyaCommandHandler : IRequestHandler<DeleteMedyaCommand, DeletedMedyaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMedyaRepository _medyaRepository;
        private readonly MedyaBusinessRules _medyaBusinessRules;

        public DeleteMedyaCommandHandler(IMapper mapper, IMedyaRepository medyaRepository,
                                         MedyaBusinessRules medyaBusinessRules)
        {
            _mapper = mapper;
            _medyaRepository = medyaRepository;
            _medyaBusinessRules = medyaBusinessRules;
        }

        public async Task<DeletedMedyaResponse> Handle(DeleteMedyaCommand request, CancellationToken cancellationToken)
        {
            Medya? medya = await _medyaRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _medyaBusinessRules.MedyaShouldExistWhenSelected(medya);

            await _medyaRepository.DeleteAsync(medya!);

            DeletedMedyaResponse response = _mapper.Map<DeletedMedyaResponse>(medya);
            return response;
        }
    }
}