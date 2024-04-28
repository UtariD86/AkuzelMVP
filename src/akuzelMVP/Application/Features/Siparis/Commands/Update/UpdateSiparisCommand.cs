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

namespace Application.Features.Siparis.Commands.Update;

public class UpdateSiparisCommand : IRequest<UpdatedSiparisResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required Guid TeklifId { get; set; }
    public required TeklifStatus SiparisStatus { get; set; }
    public required DateTime BitisDate { get; set; }
    public required Guid KuponId { get; set; }
    public required double OdenenUcret { get; set; }
    public required Guid IslemNo { get; set; }

    public string[] Roles => [Admin, Write, SiparisOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSiparis"];

    public class UpdateSiparisCommandHandler : IRequestHandler<UpdateSiparisCommand, UpdatedSiparisResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISiparisRepository _siparisRepository;
        private readonly SiparisBusinessRules _siparisBusinessRules;

        public UpdateSiparisCommandHandler(IMapper mapper, ISiparisRepository siparisRepository,
                                         SiparisBusinessRules siparisBusinessRules)
        {
            _mapper = mapper;
            _siparisRepository = siparisRepository;
            _siparisBusinessRules = siparisBusinessRules;
        }

        public async Task<UpdatedSiparisResponse> Handle(UpdateSiparisCommand request, CancellationToken cancellationToken)
        {
            Siparis? siparis = await _siparisRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _siparisBusinessRules.SiparisShouldExistWhenSelected(siparis);
            siparis = _mapper.Map(request, siparis);

            await _siparisRepository.UpdateAsync(siparis!);

            UpdatedSiparisResponse response = _mapper.Map<UpdatedSiparisResponse>(siparis);
            return response;
        }
    }
}