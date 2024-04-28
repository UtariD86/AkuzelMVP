using Application.Features.Siparis.Constants;
using Application.Features.Siparis.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using Domain.Enums;
using static Application.Features.Siparis.Constants.SiparisOperationClaims;

namespace Application.Features.Siparis.Commands.Create;

public class CreateSiparisCommand : IRequest<CreatedSiparisResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required Guid TeklifId { get; set; }
    public required TeklifStatus SiparisStatus { get; set; }
    public required DateTime BitisDate { get; set; }
    public required Guid KuponId { get; set; }
    public required double OdenenUcret { get; set; }
    public required Guid IslemNo { get; set; }

    public string[] Roles => [Admin, Write, SiparisOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSiparis"];

    public class CreateSiparisCommandHandler : IRequestHandler<CreateSiparisCommand, CreatedSiparisResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISiparisRepository _siparisRepository;
        private readonly SiparisBusinessRules _siparisBusinessRules;

        public CreateSiparisCommandHandler(IMapper mapper, ISiparisRepository siparisRepository,
                                         SiparisBusinessRules siparisBusinessRules)
        {
            _mapper = mapper;
            _siparisRepository = siparisRepository;
            _siparisBusinessRules = siparisBusinessRules;
        }

        public async Task<CreatedSiparisResponse> Handle(CreateSiparisCommand request, CancellationToken cancellationToken)
        {
            Siparis siparis = _mapper.Map<Siparis>(request);

            await _siparisRepository.AddAsync(siparis);

            CreatedSiparisResponse response = _mapper.Map<CreatedSiparisResponse>(siparis);
            return response;
        }
    }
}