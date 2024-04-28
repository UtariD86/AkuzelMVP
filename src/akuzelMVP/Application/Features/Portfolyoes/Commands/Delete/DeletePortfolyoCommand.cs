using Application.Features.Portfolyoes.Constants;
using Application.Features.Portfolyoes.Constants;
using Application.Features.Portfolyoes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Portfolyoes.Constants.PortfolyoesOperationClaims;

namespace Application.Features.Portfolyoes.Commands.Delete;

public class DeletePortfolyoCommand : IRequest<DeletedPortfolyoResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, PortfolyoesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPortfolyoes"];

    public class DeletePortfolyoCommandHandler : IRequestHandler<DeletePortfolyoCommand, DeletedPortfolyoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPortfolyoRepository _portfolyoRepository;
        private readonly PortfolyoBusinessRules _portfolyoBusinessRules;

        public DeletePortfolyoCommandHandler(IMapper mapper, IPortfolyoRepository portfolyoRepository,
                                         PortfolyoBusinessRules portfolyoBusinessRules)
        {
            _mapper = mapper;
            _portfolyoRepository = portfolyoRepository;
            _portfolyoBusinessRules = portfolyoBusinessRules;
        }

        public async Task<DeletedPortfolyoResponse> Handle(DeletePortfolyoCommand request, CancellationToken cancellationToken)
        {
            Portfolyo? portfolyo = await _portfolyoRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _portfolyoBusinessRules.PortfolyoShouldExistWhenSelected(portfolyo);

            await _portfolyoRepository.DeleteAsync(portfolyo!);

            DeletedPortfolyoResponse response = _mapper.Map<DeletedPortfolyoResponse>(portfolyo);
            return response;
        }
    }
}