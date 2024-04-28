using Application.Features.ListeVeris.Constants;
using Application.Features.ListeVeris.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using Domain.Enums;
using static Application.Features.ListeVeris.Constants.ListeVerisOperationClaims;

namespace Application.Features.ListeVeris.Commands.Create;

public class CreateListeVeriCommand : IRequest<CreatedListeVeriResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required ListeVeriType Type { get; set; }
    public Guid? UstId { get; set; }
    public required int Derinlik { get; set; }
    public required string Deger { get; set; }
    public Guid? EkId { get; set; }
    public string? EkDeger { get; set; }
    public string? Aciklama { get; set; }
    public required Guid DuzenleyenId { get; set; }

    public string[] Roles => [Admin, Write, ListeVerisOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetListeVeris"];

    public class CreateListeVeriCommandHandler : IRequestHandler<CreateListeVeriCommand, CreatedListeVeriResponse>
    {
        private readonly IMapper _mapper;
        private readonly IListeVeriRepository _listeVeriRepository;
        private readonly ListeVeriBusinessRules _listeVeriBusinessRules;

        public CreateListeVeriCommandHandler(IMapper mapper, IListeVeriRepository listeVeriRepository,
                                         ListeVeriBusinessRules listeVeriBusinessRules)
        {
            _mapper = mapper;
            _listeVeriRepository = listeVeriRepository;
            _listeVeriBusinessRules = listeVeriBusinessRules;
        }

        public async Task<CreatedListeVeriResponse> Handle(CreateListeVeriCommand request, CancellationToken cancellationToken)
        {
            ListeVeri listeVeri = _mapper.Map<ListeVeri>(request);

            await _listeVeriRepository.AddAsync(listeVeri);

            CreatedListeVeriResponse response = _mapper.Map<CreatedListeVeriResponse>(listeVeri);
            return response;
        }
    }
}