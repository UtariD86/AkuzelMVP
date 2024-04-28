using Application.Features.Portfolyoes.Constants;
using Application.Features.Portfolyoes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Portfolyoes.Constants.PortfolyoesOperationClaims;

namespace Application.Features.Portfolyoes.Queries.GetById;

public class GetByIdPortfolyoQuery : IRequest<GetByIdPortfolyoResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdPortfolyoQueryHandler : IRequestHandler<GetByIdPortfolyoQuery, GetByIdPortfolyoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPortfolyoRepository _portfolyoRepository;
        private readonly PortfolyoBusinessRules _portfolyoBusinessRules;

        public GetByIdPortfolyoQueryHandler(IMapper mapper, IPortfolyoRepository portfolyoRepository, PortfolyoBusinessRules portfolyoBusinessRules)
        {
            _mapper = mapper;
            _portfolyoRepository = portfolyoRepository;
            _portfolyoBusinessRules = portfolyoBusinessRules;
        }

        public async Task<GetByIdPortfolyoResponse> Handle(GetByIdPortfolyoQuery request, CancellationToken cancellationToken)
        {
            Portfolyo? portfolyo = await _portfolyoRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _portfolyoBusinessRules.PortfolyoShouldExistWhenSelected(portfolyo);

            GetByIdPortfolyoResponse response = _mapper.Map<GetByIdPortfolyoResponse>(portfolyo);
            return response;
        }
    }
}