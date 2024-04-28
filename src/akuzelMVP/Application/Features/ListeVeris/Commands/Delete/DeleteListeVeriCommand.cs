using Application.Features.ListeVeris.Constants;
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
using static Application.Features.ListeVeris.Constants.ListeVerisOperationClaims;

namespace Application.Features.ListeVeris.Commands.Delete;

public class DeleteListeVeriCommand : IRequest<DeletedListeVeriResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, ListeVerisOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetListeVeris"];

    public class DeleteListeVeriCommandHandler : IRequestHandler<DeleteListeVeriCommand, DeletedListeVeriResponse>
    {
        private readonly IMapper _mapper;
        private readonly IListeVeriRepository _listeVeriRepository;
        private readonly ListeVeriBusinessRules _listeVeriBusinessRules;

        public DeleteListeVeriCommandHandler(IMapper mapper, IListeVeriRepository listeVeriRepository,
                                         ListeVeriBusinessRules listeVeriBusinessRules)
        {
            _mapper = mapper;
            _listeVeriRepository = listeVeriRepository;
            _listeVeriBusinessRules = listeVeriBusinessRules;
        }

        public async Task<DeletedListeVeriResponse> Handle(DeleteListeVeriCommand request, CancellationToken cancellationToken)
        {
            ListeVeri? listeVeri = await _listeVeriRepository.GetAsync(predicate: lv => lv.Id == request.Id, cancellationToken: cancellationToken);
            await _listeVeriBusinessRules.ListeVeriShouldExistWhenSelected(listeVeri);

            await _listeVeriRepository.DeleteAsync(listeVeri!);

            DeletedListeVeriResponse response = _mapper.Map<DeletedListeVeriResponse>(listeVeri);
            return response;
        }
    }
}