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

namespace Application.Features.Portfolyoes.Commands.Update;

public class UpdatePortfolyoCommand : IRequest<UpdatedPortfolyoResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required Guid KullaniciId { get; set; }
    public Guid? SiparisId { get; set; }
    public required string Baslik { get; set; }
    public required string Aciklama { get; set; }

    public string[] Roles => [Admin, Write, PortfolyoesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPortfolyoes"];

    public class UpdatePortfolyoCommandHandler : IRequestHandler<UpdatePortfolyoCommand, UpdatedPortfolyoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPortfolyoRepository _portfolyoRepository;
        private readonly PortfolyoBusinessRules _portfolyoBusinessRules;

        public UpdatePortfolyoCommandHandler(IMapper mapper, IPortfolyoRepository portfolyoRepository,
                                         PortfolyoBusinessRules portfolyoBusinessRules)
        {
            _mapper = mapper;
            _portfolyoRepository = portfolyoRepository;
            _portfolyoBusinessRules = portfolyoBusinessRules;
        }

        public async Task<UpdatedPortfolyoResponse> Handle(UpdatePortfolyoCommand request, CancellationToken cancellationToken)
        {
            Portfolyo? portfolyo = await _portfolyoRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _portfolyoBusinessRules.PortfolyoShouldExistWhenSelected(portfolyo);
            portfolyo = _mapper.Map(request, portfolyo);

            await _portfolyoRepository.UpdateAsync(portfolyo!);

            UpdatedPortfolyoResponse response = _mapper.Map<UpdatedPortfolyoResponse>(portfolyo);
            return response;
        }
    }
}