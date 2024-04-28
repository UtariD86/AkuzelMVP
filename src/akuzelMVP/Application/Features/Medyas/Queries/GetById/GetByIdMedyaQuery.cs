using Application.Features.Medyas.Constants;
using Application.Features.Medyas.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Medyas.Constants.MedyasOperationClaims;

namespace Application.Features.Medyas.Queries.GetById;

public class GetByIdMedyaQuery : IRequest<GetByIdMedyaResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdMedyaQueryHandler : IRequestHandler<GetByIdMedyaQuery, GetByIdMedyaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMedyaRepository _medyaRepository;
        private readonly MedyaBusinessRules _medyaBusinessRules;

        public GetByIdMedyaQueryHandler(IMapper mapper, IMedyaRepository medyaRepository, MedyaBusinessRules medyaBusinessRules)
        {
            _mapper = mapper;
            _medyaRepository = medyaRepository;
            _medyaBusinessRules = medyaBusinessRules;
        }

        public async Task<GetByIdMedyaResponse> Handle(GetByIdMedyaQuery request, CancellationToken cancellationToken)
        {
            Medya? medya = await _medyaRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _medyaBusinessRules.MedyaShouldExistWhenSelected(medya);

            GetByIdMedyaResponse response = _mapper.Map<GetByIdMedyaResponse>(medya);
            return response;
        }
    }
}