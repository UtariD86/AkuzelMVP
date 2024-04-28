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

namespace Application.Features.Portfolyoes.Commands.Create;

public class CreatePortfolyoCommand : IRequest<CreatedPortfolyoResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required Guid KullaniciId { get; set; }
    public Guid? SiparisId { get; set; }
    public required string Baslik { get; set; }
    public required string Aciklama { get; set; }

    public string[] Roles => [Admin, Write, PortfolyoesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPortfolyoes"];

    public class CreatePortfolyoCommandHandler : IRequestHandler<CreatePortfolyoCommand, CreatedPortfolyoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPortfolyoRepository _portfolyoRepository;
        private readonly PortfolyoBusinessRules _portfolyoBusinessRules;

        public CreatePortfolyoCommandHandler(IMapper mapper, IPortfolyoRepository portfolyoRepository,
                                         PortfolyoBusinessRules portfolyoBusinessRules)
        {
            _mapper = mapper;
            _portfolyoRepository = portfolyoRepository;
            _portfolyoBusinessRules = portfolyoBusinessRules;
        }

        public async Task<CreatedPortfolyoResponse> Handle(CreatePortfolyoCommand request, CancellationToken cancellationToken)
        {
            Portfolyo portfolyo = _mapper.Map<Portfolyo>(request);

            await _portfolyoRepository.AddAsync(portfolyo);

            CreatedPortfolyoResponse response = _mapper.Map<CreatedPortfolyoResponse>(portfolyo);
            return response;
        }
    }
}