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

namespace Application.Features.Bildirims.Commands.Create;

public class CreateBildirimCommand : IRequest<CreatedBildirimResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required string Baslik { get; set; }
    public required string Icerik { get; set; }

    public string[] Roles => [Admin, Write, BildirimsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBildirims"];

    public class CreateBildirimCommandHandler : IRequestHandler<CreateBildirimCommand, CreatedBildirimResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBildirimRepository _bildirimRepository;
        private readonly BildirimBusinessRules _bildirimBusinessRules;

        public CreateBildirimCommandHandler(IMapper mapper, IBildirimRepository bildirimRepository,
                                         BildirimBusinessRules bildirimBusinessRules)
        {
            _mapper = mapper;
            _bildirimRepository = bildirimRepository;
            _bildirimBusinessRules = bildirimBusinessRules;
        }

        public async Task<CreatedBildirimResponse> Handle(CreateBildirimCommand request, CancellationToken cancellationToken)
        {
            Bildirim bildirim = _mapper.Map<Bildirim>(request);

            await _bildirimRepository.AddAsync(bildirim);

            CreatedBildirimResponse response = _mapper.Map<CreatedBildirimResponse>(bildirim);
            return response;
        }
    }
}