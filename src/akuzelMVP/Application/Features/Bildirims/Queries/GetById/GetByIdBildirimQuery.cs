using Application.Features.Bildirims.Constants;
using Application.Features.Bildirims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Bildirims.Constants.BildirimsOperationClaims;

namespace Application.Features.Bildirims.Queries.GetById;

public class GetByIdBildirimQuery : IRequest<GetByIdBildirimResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdBildirimQueryHandler : IRequestHandler<GetByIdBildirimQuery, GetByIdBildirimResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBildirimRepository _bildirimRepository;
        private readonly BildirimBusinessRules _bildirimBusinessRules;

        public GetByIdBildirimQueryHandler(IMapper mapper, IBildirimRepository bildirimRepository, BildirimBusinessRules bildirimBusinessRules)
        {
            _mapper = mapper;
            _bildirimRepository = bildirimRepository;
            _bildirimBusinessRules = bildirimBusinessRules;
        }

        public async Task<GetByIdBildirimResponse> Handle(GetByIdBildirimQuery request, CancellationToken cancellationToken)
        {
            Bildirim? bildirim = await _bildirimRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _bildirimBusinessRules.BildirimShouldExistWhenSelected(bildirim);

            GetByIdBildirimResponse response = _mapper.Map<GetByIdBildirimResponse>(bildirim);
            return response;
        }
    }
}