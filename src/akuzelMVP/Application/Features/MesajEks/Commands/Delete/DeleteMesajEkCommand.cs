using Application.Features.MesajEks.Constants;
using Application.Features.MesajEks.Constants;
using Application.Features.MesajEks.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.MesajEks.Constants.MesajEksOperationClaims;

namespace Application.Features.MesajEks.Commands.Delete;

public class DeleteMesajEkCommand : IRequest<DeletedMesajEkResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, MesajEksOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMesajEks"];

    public class DeleteMesajEkCommandHandler : IRequestHandler<DeleteMesajEkCommand, DeletedMesajEkResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMesajEkRepository _mesajEkRepository;
        private readonly MesajEkBusinessRules _mesajEkBusinessRules;

        public DeleteMesajEkCommandHandler(IMapper mapper, IMesajEkRepository mesajEkRepository,
                                         MesajEkBusinessRules mesajEkBusinessRules)
        {
            _mapper = mapper;
            _mesajEkRepository = mesajEkRepository;
            _mesajEkBusinessRules = mesajEkBusinessRules;
        }

        public async Task<DeletedMesajEkResponse> Handle(DeleteMesajEkCommand request, CancellationToken cancellationToken)
        {
            MesajEk? mesajEk = await _mesajEkRepository.GetAsync(predicate: me => me.Id == request.Id, cancellationToken: cancellationToken);
            await _mesajEkBusinessRules.MesajEkShouldExistWhenSelected(mesajEk);

            await _mesajEkRepository.DeleteAsync(mesajEk!);

            DeletedMesajEkResponse response = _mapper.Map<DeletedMesajEkResponse>(mesajEk);
            return response;
        }
    }
}