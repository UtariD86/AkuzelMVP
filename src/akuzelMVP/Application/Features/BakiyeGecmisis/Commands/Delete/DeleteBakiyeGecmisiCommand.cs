using Application.Features.BakiyeGecmisis.Constants;
using Application.Features.BakiyeGecmisis.Constants;
using Application.Features.BakiyeGecmisis.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.BakiyeGecmisis.Constants.BakiyeGecmisisOperationClaims;

namespace Application.Features.BakiyeGecmisis.Commands.Delete;

public class DeleteBakiyeGecmisiCommand : IRequest<DeletedBakiyeGecmisiResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, BakiyeGecmisisOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBakiyeGecmisis"];

    public class DeleteBakiyeGecmisiCommandHandler : IRequestHandler<DeleteBakiyeGecmisiCommand, DeletedBakiyeGecmisiResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBakiyeGecmisiRepository _bakiyeGecmisiRepository;
        private readonly BakiyeGecmisiBusinessRules _bakiyeGecmisiBusinessRules;

        public DeleteBakiyeGecmisiCommandHandler(IMapper mapper, IBakiyeGecmisiRepository bakiyeGecmisiRepository,
                                         BakiyeGecmisiBusinessRules bakiyeGecmisiBusinessRules)
        {
            _mapper = mapper;
            _bakiyeGecmisiRepository = bakiyeGecmisiRepository;
            _bakiyeGecmisiBusinessRules = bakiyeGecmisiBusinessRules;
        }

        public async Task<DeletedBakiyeGecmisiResponse> Handle(DeleteBakiyeGecmisiCommand request, CancellationToken cancellationToken)
        {
            BakiyeGecmisi? bakiyeGecmisi = await _bakiyeGecmisiRepository.GetAsync(predicate: bg => bg.Id == request.Id, cancellationToken: cancellationToken);
            await _bakiyeGecmisiBusinessRules.BakiyeGecmisiShouldExistWhenSelected(bakiyeGecmisi);

            await _bakiyeGecmisiRepository.DeleteAsync(bakiyeGecmisi!);

            DeletedBakiyeGecmisiResponse response = _mapper.Map<DeletedBakiyeGecmisiResponse>(bakiyeGecmisi);
            return response;
        }
    }
}