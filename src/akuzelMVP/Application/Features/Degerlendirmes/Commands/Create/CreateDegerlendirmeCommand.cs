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

namespace Application.Features.Degerlendirmes.Commands.Create;

public class CreateDegerlendirmeCommand : IRequest<CreatedDegerlendirmeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required Guid SiparisId { get; set; }
    public required Guid ProfilId { get; set; }
    public required Guid KullaniciId { get; set; }
    public required int Puan { get; set; }
    public required string Yorum { get; set; }
    public Guid? UstYorumId { get; set; }
    public required bool Onay { get; set; }
    public required int Like { get; set; }
    public required int Dislike { get; set; }

    public string[] Roles => [Admin, Write, DegerlendirmesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetDegerlendirmes"];

    public class CreateDegerlendirmeCommandHandler : IRequestHandler<CreateDegerlendirmeCommand, CreatedDegerlendirmeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDegerlendirmeRepository _degerlendirmeRepository;
        private readonly DegerlendirmeBusinessRules _degerlendirmeBusinessRules;

        public CreateDegerlendirmeCommandHandler(IMapper mapper, IDegerlendirmeRepository degerlendirmeRepository,
                                         DegerlendirmeBusinessRules degerlendirmeBusinessRules)
        {
            _mapper = mapper;
            _degerlendirmeRepository = degerlendirmeRepository;
            _degerlendirmeBusinessRules = degerlendirmeBusinessRules;
        }

        public async Task<CreatedDegerlendirmeResponse> Handle(CreateDegerlendirmeCommand request, CancellationToken cancellationToken)
        {
            Degerlendirme degerlendirme = _mapper.Map<Degerlendirme>(request);

            await _degerlendirmeRepository.AddAsync(degerlendirme);

            CreatedDegerlendirmeResponse response = _mapper.Map<CreatedDegerlendirmeResponse>(degerlendirme);
            return response;
        }
    }
}