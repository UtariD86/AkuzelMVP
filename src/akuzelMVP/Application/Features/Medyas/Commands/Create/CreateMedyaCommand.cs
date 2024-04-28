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
using Domain.Enums;
using Domain.Enums;
using static Application.Features.Medyas.Constants.MedyasOperationClaims;

namespace Application.Features.Medyas.Commands.Create;

public class CreateMedyaCommand : IRequest<CreatedMedyaResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required MedyaType MedyaType { get; set; }
    public required string Path { get; set; }
    public required MedyaAidiyet AidiyetType { get; set; }
    public required Guid AidiyetId { get; set; }
    public required Guid DuzenleyenId { get; set; }

    public string[] Roles => [Admin, Write, MedyasOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMedyas"];

    public class CreateMedyaCommandHandler : IRequestHandler<CreateMedyaCommand, CreatedMedyaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMedyaRepository _medyaRepository;
        private readonly MedyaBusinessRules _medyaBusinessRules;

        public CreateMedyaCommandHandler(IMapper mapper, IMedyaRepository medyaRepository,
                                         MedyaBusinessRules medyaBusinessRules)
        {
            _mapper = mapper;
            _medyaRepository = medyaRepository;
            _medyaBusinessRules = medyaBusinessRules;
        }

        public async Task<CreatedMedyaResponse> Handle(CreateMedyaCommand request, CancellationToken cancellationToken)
        {
            Medya medya = _mapper.Map<Medya>(request);

            await _medyaRepository.AddAsync(medya);

            CreatedMedyaResponse response = _mapper.Map<CreatedMedyaResponse>(medya);
            return response;
        }
    }
}