using Application.Features.KullaniciBildirims.Constants;
using Application.Features.KullaniciBildirims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.KullaniciBildirims.Constants.KullaniciBildirimsOperationClaims;

namespace Application.Features.KullaniciBildirims.Queries.GetById;

public class GetByIdKullaniciBildirimQuery : IRequest<GetByIdKullaniciBildirimResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdKullaniciBildirimQueryHandler : IRequestHandler<GetByIdKullaniciBildirimQuery, GetByIdKullaniciBildirimResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKullaniciBildirimRepository _kullaniciBildirimRepository;
        private readonly KullaniciBildirimBusinessRules _kullaniciBildirimBusinessRules;

        public GetByIdKullaniciBildirimQueryHandler(IMapper mapper, IKullaniciBildirimRepository kullaniciBildirimRepository, KullaniciBildirimBusinessRules kullaniciBildirimBusinessRules)
        {
            _mapper = mapper;
            _kullaniciBildirimRepository = kullaniciBildirimRepository;
            _kullaniciBildirimBusinessRules = kullaniciBildirimBusinessRules;
        }

        public async Task<GetByIdKullaniciBildirimResponse> Handle(GetByIdKullaniciBildirimQuery request, CancellationToken cancellationToken)
        {
            KullaniciBildirim? kullaniciBildirim = await _kullaniciBildirimRepository.GetAsync(predicate: kb => kb.Id == request.Id, cancellationToken: cancellationToken);
            await _kullaniciBildirimBusinessRules.KullaniciBildirimShouldExistWhenSelected(kullaniciBildirim);

            GetByIdKullaniciBildirimResponse response = _mapper.Map<GetByIdKullaniciBildirimResponse>(kullaniciBildirim);
            return response;
        }
    }
}