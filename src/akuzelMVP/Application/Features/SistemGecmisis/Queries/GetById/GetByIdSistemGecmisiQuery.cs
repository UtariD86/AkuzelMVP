using Application.Features.SistemGecmisis.Constants;
using Application.Features.SistemGecmisis.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.SistemGecmisis.Constants.SistemGecmisisOperationClaims;

namespace Application.Features.SistemGecmisis.Queries.GetById;

public class GetByIdSistemGecmisiQuery : IRequest<GetByIdSistemGecmisiResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdSistemGecmisiQueryHandler : IRequestHandler<GetByIdSistemGecmisiQuery, GetByIdSistemGecmisiResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISistemGecmisiRepository _sistemGecmisiRepository;
        private readonly SistemGecmisiBusinessRules _sistemGecmisiBusinessRules;

        public GetByIdSistemGecmisiQueryHandler(IMapper mapper, ISistemGecmisiRepository sistemGecmisiRepository, SistemGecmisiBusinessRules sistemGecmisiBusinessRules)
        {
            _mapper = mapper;
            _sistemGecmisiRepository = sistemGecmisiRepository;
            _sistemGecmisiBusinessRules = sistemGecmisiBusinessRules;
        }

        public async Task<GetByIdSistemGecmisiResponse> Handle(GetByIdSistemGecmisiQuery request, CancellationToken cancellationToken)
        {
            SistemGecmisi? sistemGecmisi = await _sistemGecmisiRepository.GetAsync(predicate: sg => sg.Id == request.Id, cancellationToken: cancellationToken);
            await _sistemGecmisiBusinessRules.SistemGecmisiShouldExistWhenSelected(sistemGecmisi);

            GetByIdSistemGecmisiResponse response = _mapper.Map<GetByIdSistemGecmisiResponse>(sistemGecmisi);
            return response;
        }
    }
}