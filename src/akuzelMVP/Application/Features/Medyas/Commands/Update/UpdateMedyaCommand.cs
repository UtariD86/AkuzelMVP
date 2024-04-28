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

namespace Application.Features.Medyas.Commands.Update;

public class UpdateMedyaCommand : IRequest<UpdatedMedyaResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required MedyaType MedyaType { get; set; }
    public required string Path { get; set; }
    public required MedyaAidiyet AidiyetType { get; set; }
    public required Guid AidiyetId { get; set; }
    public required Guid DuzenleyenId { get; set; }

    public string[] Roles => [Admin, Write, MedyasOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMedyas"];

    public class UpdateMedyaCommandHandler : IRequestHandler<UpdateMedyaCommand, UpdatedMedyaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMedyaRepository _medyaRepository;
        private readonly MedyaBusinessRules _medyaBusinessRules;

        public UpdateMedyaCommandHandler(IMapper mapper, IMedyaRepository medyaRepository,
                                         MedyaBusinessRules medyaBusinessRules)
        {
            _mapper = mapper;
            _medyaRepository = medyaRepository;
            _medyaBusinessRules = medyaBusinessRules;
        }

        public async Task<UpdatedMedyaResponse> Handle(UpdateMedyaCommand request, CancellationToken cancellationToken)
        {
            Medya? medya = await _medyaRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _medyaBusinessRules.MedyaShouldExistWhenSelected(medya);
            medya = _mapper.Map(request, medya);

            await _medyaRepository.UpdateAsync(medya!);

            UpdatedMedyaResponse response = _mapper.Map<UpdatedMedyaResponse>(medya);
            return response;
        }
    }
}