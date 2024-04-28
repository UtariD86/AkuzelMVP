using Application.Features.Takims.Constants;
using Application.Features.Takims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Takims.Constants.TakimsOperationClaims;

namespace Application.Features.Takims.Queries.GetById;

public class GetByIdTakimQuery : IRequest<GetByIdTakimResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdTakimQueryHandler : IRequestHandler<GetByIdTakimQuery, GetByIdTakimResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITakimRepository _takimRepository;
        private readonly TakimBusinessRules _takimBusinessRules;

        public GetByIdTakimQueryHandler(IMapper mapper, ITakimRepository takimRepository, TakimBusinessRules takimBusinessRules)
        {
            _mapper = mapper;
            _takimRepository = takimRepository;
            _takimBusinessRules = takimBusinessRules;
        }

        public async Task<GetByIdTakimResponse> Handle(GetByIdTakimQuery request, CancellationToken cancellationToken)
        {
            Takim? takim = await _takimRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _takimBusinessRules.TakimShouldExistWhenSelected(takim);

            GetByIdTakimResponse response = _mapper.Map<GetByIdTakimResponse>(takim);
            return response;
        }
    }
}