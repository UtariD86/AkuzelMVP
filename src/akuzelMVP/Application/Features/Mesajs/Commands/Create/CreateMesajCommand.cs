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

namespace Application.Features.Mesajs.Commands.Create;

public class CreateMesajCommand : IRequest<CreatedMesajResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required Guid SenderId { get; set; }
    public required Guid RecieverId { get; set; }
    public Guid? TicketId { get; set; }
    public required string Icerik { get; set; }
    public required DateTime TimaStamp { get; set; }
    public required bool Okundu { get; set; }

    public string[] Roles => [Admin, Write, MesajsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMesajs"];

    public class CreateMesajCommandHandler : IRequestHandler<CreateMesajCommand, CreatedMesajResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMesajRepository _mesajRepository;
        private readonly MesajBusinessRules _mesajBusinessRules;

        public CreateMesajCommandHandler(IMapper mapper, IMesajRepository mesajRepository,
                                         MesajBusinessRules mesajBusinessRules)
        {
            _mapper = mapper;
            _mesajRepository = mesajRepository;
            _mesajBusinessRules = mesajBusinessRules;
        }

        public async Task<CreatedMesajResponse> Handle(CreateMesajCommand request, CancellationToken cancellationToken)
        {
            Mesaj mesaj = _mapper.Map<Mesaj>(request);

            await _mesajRepository.AddAsync(mesaj);

            CreatedMesajResponse response = _mapper.Map<CreatedMesajResponse>(mesaj);
            return response;
        }
    }
}