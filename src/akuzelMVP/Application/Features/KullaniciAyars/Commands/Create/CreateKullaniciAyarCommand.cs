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

namespace Application.Features.KullaniciAyars.Commands.Create;

public class CreateKullaniciAyarCommand : IRequest<CreatedKullaniciAyarResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required KullaniciAyarType AyarType { get; set; }
    public required Guid KullaniciId { get; set; }
    public required string Key { get; set; }
    public required string Value { get; set; }

    public string[] Roles => [Admin, Write, KullaniciAyarsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetKullaniciAyars"];

    public class CreateKullaniciAyarCommandHandler : IRequestHandler<CreateKullaniciAyarCommand, CreatedKullaniciAyarResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKullaniciAyarRepository _kullaniciAyarRepository;
        private readonly KullaniciAyarBusinessRules _kullaniciAyarBusinessRules;

        public CreateKullaniciAyarCommandHandler(IMapper mapper, IKullaniciAyarRepository kullaniciAyarRepository,
                                         KullaniciAyarBusinessRules kullaniciAyarBusinessRules)
        {
            _mapper = mapper;
            _kullaniciAyarRepository = kullaniciAyarRepository;
            _kullaniciAyarBusinessRules = kullaniciAyarBusinessRules;
        }

        public async Task<CreatedKullaniciAyarResponse> Handle(CreateKullaniciAyarCommand request, CancellationToken cancellationToken)
        {
            KullaniciAyar kullaniciAyar = _mapper.Map<KullaniciAyar>(request);

            await _kullaniciAyarRepository.AddAsync(kullaniciAyar);

            CreatedKullaniciAyarResponse response = _mapper.Map<CreatedKullaniciAyarResponse>(kullaniciAyar);
            return response;
        }
    }
}