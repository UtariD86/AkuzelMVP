using Application.Features.Degerlendirmes.Constants;
using Application.Features.Degerlendirmes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Degerlendirmes.Constants.DegerlendirmesOperationClaims;

namespace Application.Features.Degerlendirmes.Queries.GetById;

public class GetByIdDegerlendirmeQuery : IRequest<GetByIdDegerlendirmeResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdDegerlendirmeQueryHandler : IRequestHandler<GetByIdDegerlendirmeQuery, GetByIdDegerlendirmeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDegerlendirmeRepository _degerlendirmeRepository;
        private readonly DegerlendirmeBusinessRules _degerlendirmeBusinessRules;

        public GetByIdDegerlendirmeQueryHandler(IMapper mapper, IDegerlendirmeRepository degerlendirmeRepository, DegerlendirmeBusinessRules degerlendirmeBusinessRules)
        {
            _mapper = mapper;
            _degerlendirmeRepository = degerlendirmeRepository;
            _degerlendirmeBusinessRules = degerlendirmeBusinessRules;
        }

        public async Task<GetByIdDegerlendirmeResponse> Handle(GetByIdDegerlendirmeQuery request, CancellationToken cancellationToken)
        {
            Degerlendirme? degerlendirme = await _degerlendirmeRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _degerlendirmeBusinessRules.DegerlendirmeShouldExistWhenSelected(degerlendirme);

            GetByIdDegerlendirmeResponse response = _mapper.Map<GetByIdDegerlendirmeResponse>(degerlendirme);
            return response;
        }
    }
}