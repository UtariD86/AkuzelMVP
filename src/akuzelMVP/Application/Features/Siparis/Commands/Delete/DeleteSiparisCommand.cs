using Application.Features.Siparis.Constants;
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
using static Application.Features.Siparis.Constants.SiparisOperationClaims;

namespace Application.Features.Siparis.Commands.Delete;

public class DeleteSiparisCommand : IRequest<DeletedSiparisResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, SiparisOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSiparis"];

    public class DeleteSiparisCommandHandler : IRequestHandler<DeleteSiparisCommand, DeletedSiparisResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISiparisRepository _siparisRepository;
        private readonly SiparisBusinessRules _siparisBusinessRules;

        public DeleteSiparisCommandHandler(IMapper mapper, ISiparisRepository siparisRepository,
                                         SiparisBusinessRules siparisBusinessRules)
        {
            _mapper = mapper;
            _siparisRepository = siparisRepository;
            _siparisBusinessRules = siparisBusinessRules;
        }

        public async Task<DeletedSiparisResponse> Handle(DeleteSiparisCommand request, CancellationToken cancellationToken)
        {
            Siparis? siparis = await _siparisRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _siparisBusinessRules.SiparisShouldExistWhenSelected(siparis);

            await _siparisRepository.DeleteAsync(siparis!);

            DeletedSiparisResponse response = _mapper.Map<DeletedSiparisResponse>(siparis);
            return response;
        }
    }
}