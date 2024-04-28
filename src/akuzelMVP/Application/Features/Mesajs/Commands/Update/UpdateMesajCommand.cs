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

namespace Application.Features.Mesajs.Commands.Update;

public class UpdateMesajCommand : IRequest<UpdatedMesajResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required Guid SenderId { get; set; }
    public required Guid RecieverId { get; set; }
    public Guid? TicketId { get; set; }
    public required string Icerik { get; set; }
    public required DateTime TimaStamp { get; set; }
    public required bool Okundu { get; set; }

    public string[] Roles => [Admin, Write, MesajsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMesajs"];

    public class UpdateMesajCommandHandler : IRequestHandler<UpdateMesajCommand, UpdatedMesajResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMesajRepository _mesajRepository;
        private readonly MesajBusinessRules _mesajBusinessRules;

        public UpdateMesajCommandHandler(IMapper mapper, IMesajRepository mesajRepository,
                                         MesajBusinessRules mesajBusinessRules)
        {
            _mapper = mapper;
            _mesajRepository = mesajRepository;
            _mesajBusinessRules = mesajBusinessRules;
        }

        public async Task<UpdatedMesajResponse> Handle(UpdateMesajCommand request, CancellationToken cancellationToken)
        {
            Mesaj? mesaj = await _mesajRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _mesajBusinessRules.MesajShouldExistWhenSelected(mesaj);
            mesaj = _mapper.Map(request, mesaj);

            await _mesajRepository.UpdateAsync(mesaj!);

            UpdatedMesajResponse response = _mapper.Map<UpdatedMesajResponse>(mesaj);
            return response;
        }
    }
}