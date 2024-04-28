using Application.Features.KullaniciTakims.Constants;
using Application.Features.KullaniciTakims.Constants;
using Application.Features.KullaniciTakims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.KullaniciTakims.Constants.KullaniciTakimsOperationClaims;

namespace Application.Features.KullaniciTakims.Commands.Delete;

public class DeleteKullaniciTakimCommand : IRequest<DeletedKullaniciTakimResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, KullaniciTakimsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetKullaniciTakims"];

    public class DeleteKullaniciTakimCommandHandler : IRequestHandler<DeleteKullaniciTakimCommand, DeletedKullaniciTakimResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKullaniciTakimRepository _kullaniciTakimRepository;
        private readonly KullaniciTakimBusinessRules _kullaniciTakimBusinessRules;

        public DeleteKullaniciTakimCommandHandler(IMapper mapper, IKullaniciTakimRepository kullaniciTakimRepository,
                                         KullaniciTakimBusinessRules kullaniciTakimBusinessRules)
        {
            _mapper = mapper;
            _kullaniciTakimRepository = kullaniciTakimRepository;
            _kullaniciTakimBusinessRules = kullaniciTakimBusinessRules;
        }

        public async Task<DeletedKullaniciTakimResponse> Handle(DeleteKullaniciTakimCommand request, CancellationToken cancellationToken)
        {
            KullaniciTakim? kullaniciTakim = await _kullaniciTakimRepository.GetAsync(predicate: kt => kt.Id == request.Id, cancellationToken: cancellationToken);
            await _kullaniciTakimBusinessRules.KullaniciTakimShouldExistWhenSelected(kullaniciTakim);

            await _kullaniciTakimRepository.DeleteAsync(kullaniciTakim!);

            DeletedKullaniciTakimResponse response = _mapper.Map<DeletedKullaniciTakimResponse>(kullaniciTakim);
            return response;
        }
    }
}