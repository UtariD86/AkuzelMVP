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
using Domain.Enums;
using static Application.Features.MesajEks.Constants.MesajEksOperationClaims;

namespace Application.Features.MesajEks.Commands.Update;

public class UpdateMesajEkCommand : IRequest<UpdatedMesajEkResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required bool BildirimMi { get; set; }
    public required Guid MesajId { get; set; }
    public required MedyaType EkType { get; set; }
    public required string Icerik { get; set; }

    public string[] Roles => [Admin, Write, MesajEksOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMesajEks"];

    public class UpdateMesajEkCommandHandler : IRequestHandler<UpdateMesajEkCommand, UpdatedMesajEkResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMesajEkRepository _mesajEkRepository;
        private readonly MesajEkBusinessRules _mesajEkBusinessRules;

        public UpdateMesajEkCommandHandler(IMapper mapper, IMesajEkRepository mesajEkRepository,
                                         MesajEkBusinessRules mesajEkBusinessRules)
        {
            _mapper = mapper;
            _mesajEkRepository = mesajEkRepository;
            _mesajEkBusinessRules = mesajEkBusinessRules;
        }

        public async Task<UpdatedMesajEkResponse> Handle(UpdateMesajEkCommand request, CancellationToken cancellationToken)
        {
            MesajEk? mesajEk = await _mesajEkRepository.GetAsync(predicate: me => me.Id == request.Id, cancellationToken: cancellationToken);
            await _mesajEkBusinessRules.MesajEkShouldExistWhenSelected(mesajEk);
            mesajEk = _mapper.Map(request, mesajEk);

            await _mesajEkRepository.UpdateAsync(mesajEk!);

            UpdatedMesajEkResponse response = _mapper.Map<UpdatedMesajEkResponse>(mesajEk);
            return response;
        }
    }
}