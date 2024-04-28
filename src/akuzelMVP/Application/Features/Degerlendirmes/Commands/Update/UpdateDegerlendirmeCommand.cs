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

namespace Application.Features.Degerlendirmes.Commands.Update;

public class UpdateDegerlendirmeCommand : IRequest<UpdatedDegerlendirmeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required Guid SiparisId { get; set; }
    public required Guid ProfilId { get; set; }
    public required Guid KullaniciId { get; set; }
    public required int Puan { get; set; }
    public required string Yorum { get; set; }
    public Guid? UstYorumId { get; set; }
    public required bool Onay { get; set; }
    public required int Like { get; set; }
    public required int Dislike { get; set; }

    public string[] Roles => [Admin, Write, DegerlendirmesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetDegerlendirmes"];

    public class UpdateDegerlendirmeCommandHandler : IRequestHandler<UpdateDegerlendirmeCommand, UpdatedDegerlendirmeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDegerlendirmeRepository _degerlendirmeRepository;
        private readonly DegerlendirmeBusinessRules _degerlendirmeBusinessRules;

        public UpdateDegerlendirmeCommandHandler(IMapper mapper, IDegerlendirmeRepository degerlendirmeRepository,
                                         DegerlendirmeBusinessRules degerlendirmeBusinessRules)
        {
            _mapper = mapper;
            _degerlendirmeRepository = degerlendirmeRepository;
            _degerlendirmeBusinessRules = degerlendirmeBusinessRules;
        }

        public async Task<UpdatedDegerlendirmeResponse> Handle(UpdateDegerlendirmeCommand request, CancellationToken cancellationToken)
        {
            Degerlendirme? degerlendirme = await _degerlendirmeRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _degerlendirmeBusinessRules.DegerlendirmeShouldExistWhenSelected(degerlendirme);
            degerlendirme = _mapper.Map(request, degerlendirme);

            await _degerlendirmeRepository.UpdateAsync(degerlendirme!);

            UpdatedDegerlendirmeResponse response = _mapper.Map<UpdatedDegerlendirmeResponse>(degerlendirme);
            return response;
        }
    }
}