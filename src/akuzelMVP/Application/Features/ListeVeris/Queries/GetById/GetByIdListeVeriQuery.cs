using Application.Features.ListeVeris.Constants;
using Application.Features.ListeVeris.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ListeVeris.Constants.ListeVerisOperationClaims;

namespace Application.Features.ListeVeris.Queries.GetById;

public class GetByIdListeVeriQuery : IRequest<GetByIdListeVeriResponse>/*, ISecuredRequest*/
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdListeVeriQueryHandler : IRequestHandler<GetByIdListeVeriQuery, GetByIdListeVeriResponse>
    {
        private readonly IMapper _mapper;
        private readonly IListeVeriRepository _listeVeriRepository;
        private readonly ListeVeriBusinessRules _listeVeriBusinessRules;

        public GetByIdListeVeriQueryHandler(IMapper mapper, IListeVeriRepository listeVeriRepository, ListeVeriBusinessRules listeVeriBusinessRules)
        {
            _mapper = mapper;
            _listeVeriRepository = listeVeriRepository;
            _listeVeriBusinessRules = listeVeriBusinessRules;
        }

        public async Task<GetByIdListeVeriResponse> Handle(GetByIdListeVeriQuery request, CancellationToken cancellationToken)
        {
            ListeVeri? listeVeri = await _listeVeriRepository.GetAsync(predicate: lv => lv.Id == request.Id, cancellationToken: cancellationToken);
            await _listeVeriBusinessRules.ListeVeriShouldExistWhenSelected(listeVeri);

            GetByIdListeVeriResponse response = _mapper.Map<GetByIdListeVeriResponse>(listeVeri);
            return response;
        }
    }
}