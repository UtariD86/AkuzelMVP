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
using Domain.Enums;
using static Application.Features.KullaniciAyars.Constants.KullaniciAyarsOperationClaims;

namespace Application.Features.KullaniciAyars.Commands.Update;

public class UpdateKullaniciAyarCommand : IRequest<UpdatedKullaniciAyarResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required KullaniciAyarType AyarType { get; set; }
    public required Guid KullaniciId { get; set; }
    public required string Key { get; set; }
    public required string Value { get; set; }

    public string[] Roles => [Admin, Write, KullaniciAyarsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetKullaniciAyars"];

    public class UpdateKullaniciAyarCommandHandler : IRequestHandler<UpdateKullaniciAyarCommand, UpdatedKullaniciAyarResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKullaniciAyarRepository _kullaniciAyarRepository;
        private readonly KullaniciAyarBusinessRules _kullaniciAyarBusinessRules;

        public UpdateKullaniciAyarCommandHandler(IMapper mapper, IKullaniciAyarRepository kullaniciAyarRepository,
                                         KullaniciAyarBusinessRules kullaniciAyarBusinessRules)
        {
            _mapper = mapper;
            _kullaniciAyarRepository = kullaniciAyarRepository;
            _kullaniciAyarBusinessRules = kullaniciAyarBusinessRules;
        }

        public async Task<UpdatedKullaniciAyarResponse> Handle(UpdateKullaniciAyarCommand request, CancellationToken cancellationToken)
        {
            KullaniciAyar? kullaniciAyar = await _kullaniciAyarRepository.GetAsync(predicate: ka => ka.Id == request.Id, cancellationToken: cancellationToken);
            await _kullaniciAyarBusinessRules.KullaniciAyarShouldExistWhenSelected(kullaniciAyar);
            kullaniciAyar = _mapper.Map(request, kullaniciAyar);

            await _kullaniciAyarRepository.UpdateAsync(kullaniciAyar!);

            UpdatedKullaniciAyarResponse response = _mapper.Map<UpdatedKullaniciAyarResponse>(kullaniciAyar);
            return response;
        }
    }
}