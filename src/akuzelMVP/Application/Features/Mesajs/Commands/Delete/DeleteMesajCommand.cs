using Application.Features.Mesajs.Constants;
using Application.Features.Mesajs.Constants;
using Application.Features.Mesajs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Mesajs.Constants.MesajsOperationClaims;

namespace Application.Features.Mesajs.Commands.Delete;

public class DeleteMesajCommand : IRequest<DeletedMesajResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, MesajsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMesajs"];

    public class DeleteMesajCommandHandler : IRequestHandler<DeleteMesajCommand, DeletedMesajResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMesajRepository _mesajRepository;
        private readonly MesajBusinessRules _mesajBusinessRules;

        public DeleteMesajCommandHandler(IMapper mapper, IMesajRepository mesajRepository,
                                         MesajBusinessRules mesajBusinessRules)
        {
            _mapper = mapper;
            _mesajRepository = mesajRepository;
            _mesajBusinessRules = mesajBusinessRules;
        }

        public async Task<DeletedMesajResponse> Handle(DeleteMesajCommand request, CancellationToken cancellationToken)
        {
            Mesaj? mesaj = await _mesajRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _mesajBusinessRules.MesajShouldExistWhenSelected(mesaj);

            await _mesajRepository.DeleteAsync(mesaj!);

            DeletedMesajResponse response = _mapper.Map<DeletedMesajResponse>(mesaj);
            return response;
        }
    }
}