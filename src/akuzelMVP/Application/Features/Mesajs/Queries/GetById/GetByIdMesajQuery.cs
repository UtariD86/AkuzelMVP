using Application.Features.Mesajs.Constants;
using Application.Features.Mesajs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Mesajs.Constants.MesajsOperationClaims;

namespace Application.Features.Mesajs.Queries.GetById;

public class GetByIdMesajQuery : IRequest<GetByIdMesajResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdMesajQueryHandler : IRequestHandler<GetByIdMesajQuery, GetByIdMesajResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMesajRepository _mesajRepository;
        private readonly MesajBusinessRules _mesajBusinessRules;

        public GetByIdMesajQueryHandler(IMapper mapper, IMesajRepository mesajRepository, MesajBusinessRules mesajBusinessRules)
        {
            _mapper = mapper;
            _mesajRepository = mesajRepository;
            _mesajBusinessRules = mesajBusinessRules;
        }

        public async Task<GetByIdMesajResponse> Handle(GetByIdMesajQuery request, CancellationToken cancellationToken)
        {
            Mesaj? mesaj = await _mesajRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _mesajBusinessRules.MesajShouldExistWhenSelected(mesaj);

            GetByIdMesajResponse response = _mapper.Map<GetByIdMesajResponse>(mesaj);
            return response;
        }
    }
}