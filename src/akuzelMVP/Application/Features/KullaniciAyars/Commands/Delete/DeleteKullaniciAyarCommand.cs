using Application.Features.KullaniciAyars.Constants;
using Application.Features.KullaniciAyars.Constants;
using Application.Features.KullaniciAyars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.KullaniciAyars.Constants.KullaniciAyarsOperationClaims;

namespace Application.Features.KullaniciAyars.Commands.Delete;

public class DeleteKullaniciAyarCommand : IRequest<DeletedKullaniciAyarResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, KullaniciAyarsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetKullaniciAyars"];

    public class DeleteKullaniciAyarCommandHandler : IRequestHandler<DeleteKullaniciAyarCommand, DeletedKullaniciAyarResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKullaniciAyarRepository _kullaniciAyarRepository;
        private readonly KullaniciAyarBusinessRules _kullaniciAyarBusinessRules;

        public DeleteKullaniciAyarCommandHandler(IMapper mapper, IKullaniciAyarRepository kullaniciAyarRepository,
                                         KullaniciAyarBusinessRules kullaniciAyarBusinessRules)
        {
            _mapper = mapper;
            _kullaniciAyarRepository = kullaniciAyarRepository;
            _kullaniciAyarBusinessRules = kullaniciAyarBusinessRules;
        }

        public async Task<DeletedKullaniciAyarResponse> Handle(DeleteKullaniciAyarCommand request, CancellationToken cancellationToken)
        {
            KullaniciAyar? kullaniciAyar = await _kullaniciAyarRepository.GetAsync(predicate: ka => ka.Id == request.Id, cancellationToken: cancellationToken);
            await _kullaniciAyarBusinessRules.KullaniciAyarShouldExistWhenSelected(kullaniciAyar);

            await _kullaniciAyarRepository.DeleteAsync(kullaniciAyar!);

            DeletedKullaniciAyarResponse response = _mapper.Map<DeletedKullaniciAyarResponse>(kullaniciAyar);
            return response;
        }
    }
}