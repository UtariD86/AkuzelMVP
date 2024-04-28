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

namespace Application.Features.Bildirims.Commands.Update;

public class UpdateBildirimCommand : IRequest<UpdatedBildirimResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required string Baslik { get; set; }
    public required string Icerik { get; set; }

    public string[] Roles => [Admin, Write, BildirimsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBildirims"];

    public class UpdateBildirimCommandHandler : IRequestHandler<UpdateBildirimCommand, UpdatedBildirimResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBildirimRepository _bildirimRepository;
        private readonly BildirimBusinessRules _bildirimBusinessRules;

        public UpdateBildirimCommandHandler(IMapper mapper, IBildirimRepository bildirimRepository,
                                         BildirimBusinessRules bildirimBusinessRules)
        {
            _mapper = mapper;
            _bildirimRepository = bildirimRepository;
            _bildirimBusinessRules = bildirimBusinessRules;
        }

        public async Task<UpdatedBildirimResponse> Handle(UpdateBildirimCommand request, CancellationToken cancellationToken)
        {
            Bildirim? bildirim = await _bildirimRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _bildirimBusinessRules.BildirimShouldExistWhenSelected(bildirim);
            bildirim = _mapper.Map(request, bildirim);

            await _bildirimRepository.UpdateAsync(bildirim!);

            UpdatedBildirimResponse response = _mapper.Map<UpdatedBildirimResponse>(bildirim);
            return response;
        }
    }
}