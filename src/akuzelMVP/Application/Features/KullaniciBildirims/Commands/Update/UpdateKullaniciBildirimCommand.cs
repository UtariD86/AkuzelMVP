using Application.Features.KullaniciBildirims.Constants;
using Application.Features.KullaniciBildirims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.KullaniciBildirims.Constants.KullaniciBildirimsOperationClaims;

namespace Application.Features.KullaniciBildirims.Commands.Update;

public class UpdateKullaniciBildirimCommand : IRequest<UpdatedKullaniciBildirimResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required Guid KullaniciId { get; set; }
    public required Guid BildirimId { get; set; }
    public required bool Goruldu { get; set; }

    public string[] Roles => [Admin, Write, KullaniciBildirimsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetKullaniciBildirims"];

    public class UpdateKullaniciBildirimCommandHandler : IRequestHandler<UpdateKullaniciBildirimCommand, UpdatedKullaniciBildirimResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKullaniciBildirimRepository _kullaniciBildirimRepository;
        private readonly KullaniciBildirimBusinessRules _kullaniciBildirimBusinessRules;

        public UpdateKullaniciBildirimCommandHandler(IMapper mapper, IKullaniciBildirimRepository kullaniciBildirimRepository,
                                         KullaniciBildirimBusinessRules kullaniciBildirimBusinessRules)
        {
            _mapper = mapper;
            _kullaniciBildirimRepository = kullaniciBildirimRepository;
            _kullaniciBildirimBusinessRules = kullaniciBildirimBusinessRules;
        }

        public async Task<UpdatedKullaniciBildirimResponse> Handle(UpdateKullaniciBildirimCommand request, CancellationToken cancellationToken)
        {
            KullaniciBildirim? kullaniciBildirim = await _kullaniciBildirimRepository.GetAsync(predicate: kb => kb.Id == request.Id, cancellationToken: cancellationToken);
            await _kullaniciBildirimBusinessRules.KullaniciBildirimShouldExistWhenSelected(kullaniciBildirim);
            kullaniciBildirim = _mapper.Map(request, kullaniciBildirim);

            await _kullaniciBildirimRepository.UpdateAsync(kullaniciBildirim!);

            UpdatedKullaniciBildirimResponse response = _mapper.Map<UpdatedKullaniciBildirimResponse>(kullaniciBildirim);
            return response;
        }
    }
}