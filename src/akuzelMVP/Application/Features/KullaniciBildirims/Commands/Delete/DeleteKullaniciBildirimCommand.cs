using Application.Features.KullaniciBildirims.Constants;
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

namespace Application.Features.KullaniciBildirims.Commands.Delete;

public class DeleteKullaniciBildirimCommand : IRequest<DeletedKullaniciBildirimResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, KullaniciBildirimsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetKullaniciBildirims"];

    public class DeleteKullaniciBildirimCommandHandler : IRequestHandler<DeleteKullaniciBildirimCommand, DeletedKullaniciBildirimResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKullaniciBildirimRepository _kullaniciBildirimRepository;
        private readonly KullaniciBildirimBusinessRules _kullaniciBildirimBusinessRules;

        public DeleteKullaniciBildirimCommandHandler(IMapper mapper, IKullaniciBildirimRepository kullaniciBildirimRepository,
                                         KullaniciBildirimBusinessRules kullaniciBildirimBusinessRules)
        {
            _mapper = mapper;
            _kullaniciBildirimRepository = kullaniciBildirimRepository;
            _kullaniciBildirimBusinessRules = kullaniciBildirimBusinessRules;
        }

        public async Task<DeletedKullaniciBildirimResponse> Handle(DeleteKullaniciBildirimCommand request, CancellationToken cancellationToken)
        {
            KullaniciBildirim? kullaniciBildirim = await _kullaniciBildirimRepository.GetAsync(predicate: kb => kb.Id == request.Id, cancellationToken: cancellationToken);
            await _kullaniciBildirimBusinessRules.KullaniciBildirimShouldExistWhenSelected(kullaniciBildirim);

            await _kullaniciBildirimRepository.DeleteAsync(kullaniciBildirim!);

            DeletedKullaniciBildirimResponse response = _mapper.Map<DeletedKullaniciBildirimResponse>(kullaniciBildirim);
            return response;
        }
    }
}