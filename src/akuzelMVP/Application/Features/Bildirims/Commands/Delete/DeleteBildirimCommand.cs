using Application.Features.Bildirims.Constants;
using Application.Features.Bildirims.Constants;
using Application.Features.Bildirims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Bildirims.Constants.BildirimsOperationClaims;

namespace Application.Features.Bildirims.Commands.Delete;

public class DeleteBildirimCommand : IRequest<DeletedBildirimResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, BildirimsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBildirims"];

    public class DeleteBildirimCommandHandler : IRequestHandler<DeleteBildirimCommand, DeletedBildirimResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBildirimRepository _bildirimRepository;
        private readonly BildirimBusinessRules _bildirimBusinessRules;

        public DeleteBildirimCommandHandler(IMapper mapper, IBildirimRepository bildirimRepository,
                                         BildirimBusinessRules bildirimBusinessRules)
        {
            _mapper = mapper;
            _bildirimRepository = bildirimRepository;
            _bildirimBusinessRules = bildirimBusinessRules;
        }

        public async Task<DeletedBildirimResponse> Handle(DeleteBildirimCommand request, CancellationToken cancellationToken)
        {
            Bildirim? bildirim = await _bildirimRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _bildirimBusinessRules.BildirimShouldExistWhenSelected(bildirim);

            await _bildirimRepository.DeleteAsync(bildirim!);

            DeletedBildirimResponse response = _mapper.Map<DeletedBildirimResponse>(bildirim);
            return response;
        }
    }
}