using Application.Features.BakiyeGecmisis.Constants;
using Application.Features.BakiyeGecmisis.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BakiyeGecmisis.Constants.BakiyeGecmisisOperationClaims;

namespace Application.Features.BakiyeGecmisis.Queries.GetById;

public class GetByIdBakiyeGecmisiQuery : IRequest<GetByIdBakiyeGecmisiResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdBakiyeGecmisiQueryHandler : IRequestHandler<GetByIdBakiyeGecmisiQuery, GetByIdBakiyeGecmisiResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBakiyeGecmisiRepository _bakiyeGecmisiRepository;
        private readonly BakiyeGecmisiBusinessRules _bakiyeGecmisiBusinessRules;

        public GetByIdBakiyeGecmisiQueryHandler(IMapper mapper, IBakiyeGecmisiRepository bakiyeGecmisiRepository, BakiyeGecmisiBusinessRules bakiyeGecmisiBusinessRules)
        {
            _mapper = mapper;
            _bakiyeGecmisiRepository = bakiyeGecmisiRepository;
            _bakiyeGecmisiBusinessRules = bakiyeGecmisiBusinessRules;
        }

        public async Task<GetByIdBakiyeGecmisiResponse> Handle(GetByIdBakiyeGecmisiQuery request, CancellationToken cancellationToken)
        {
            BakiyeGecmisi? bakiyeGecmisi = await _bakiyeGecmisiRepository.GetAsync(predicate: bg => bg.Id == request.Id, cancellationToken: cancellationToken);
            await _bakiyeGecmisiBusinessRules.BakiyeGecmisiShouldExistWhenSelected(bakiyeGecmisi);

            GetByIdBakiyeGecmisiResponse response = _mapper.Map<GetByIdBakiyeGecmisiResponse>(bakiyeGecmisi);
            return response;
        }
    }
}