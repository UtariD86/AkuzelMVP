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

namespace Application.Features.ListeVeris.Commands.Update;

public class UpdateListeVeriCommand : IRequest<UpdatedListeVeriResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required ListeVeriType Type { get; set; }
    public Guid? UstId { get; set; }
    public required int Derinlik { get; set; }
    public required string Deger { get; set; }
    public Guid? EkId { get; set; }
    public string? EkDeger { get; set; }
    public string? Aciklama { get; set; }
    public required Guid DuzenleyenId { get; set; }

    public string[] Roles => [Admin, Write, ListeVerisOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetListeVeris"];

    public class UpdateListeVeriCommandHandler : IRequestHandler<UpdateListeVeriCommand, UpdatedListeVeriResponse>
    {
        private readonly IMapper _mapper;
        private readonly IListeVeriRepository _listeVeriRepository;
        private readonly ListeVeriBusinessRules _listeVeriBusinessRules;

        public UpdateListeVeriCommandHandler(IMapper mapper, IListeVeriRepository listeVeriRepository,
                                         ListeVeriBusinessRules listeVeriBusinessRules)
        {
            _mapper = mapper;
            _listeVeriRepository = listeVeriRepository;
            _listeVeriBusinessRules = listeVeriBusinessRules;
        }

        public async Task<UpdatedListeVeriResponse> Handle(UpdateListeVeriCommand request, CancellationToken cancellationToken)
        {
            ListeVeri? listeVeri = await _listeVeriRepository.GetAsync(predicate: lv => lv.Id == request.Id, cancellationToken: cancellationToken);
            await _listeVeriBusinessRules.ListeVeriShouldExistWhenSelected(listeVeri);
            listeVeri = _mapper.Map(request, listeVeri);

            await _listeVeriRepository.UpdateAsync(listeVeri!);

            UpdatedListeVeriResponse response = _mapper.Map<UpdatedListeVeriResponse>(listeVeri);
            return response;
        }
    }
}