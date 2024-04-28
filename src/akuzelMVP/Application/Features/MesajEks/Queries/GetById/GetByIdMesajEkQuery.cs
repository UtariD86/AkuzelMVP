using Application.Features.MesajEks.Constants;
using Application.Features.MesajEks.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MesajEks.Constants.MesajEksOperationClaims;

namespace Application.Features.MesajEks.Queries.GetById;

public class GetByIdMesajEkQuery : IRequest<GetByIdMesajEkResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdMesajEkQueryHandler : IRequestHandler<GetByIdMesajEkQuery, GetByIdMesajEkResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMesajEkRepository _mesajEkRepository;
        private readonly MesajEkBusinessRules _mesajEkBusinessRules;

        public GetByIdMesajEkQueryHandler(IMapper mapper, IMesajEkRepository mesajEkRepository, MesajEkBusinessRules mesajEkBusinessRules)
        {
            _mapper = mapper;
            _mesajEkRepository = mesajEkRepository;
            _mesajEkBusinessRules = mesajEkBusinessRules;
        }

        public async Task<GetByIdMesajEkResponse> Handle(GetByIdMesajEkQuery request, CancellationToken cancellationToken)
        {
            MesajEk? mesajEk = await _mesajEkRepository.GetAsync(predicate: me => me.Id == request.Id, cancellationToken: cancellationToken);
            await _mesajEkBusinessRules.MesajEkShouldExistWhenSelected(mesajEk);

            GetByIdMesajEkResponse response = _mapper.Map<GetByIdMesajEkResponse>(mesajEk);
            return response;
        }
    }
}