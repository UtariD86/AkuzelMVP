using Application.Features.KullaniciTakims.Constants;
using Application.Features.KullaniciTakims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.KullaniciTakims.Constants.KullaniciTakimsOperationClaims;

namespace Application.Features.KullaniciTakims.Queries.GetById;

public class GetByIdKullaniciTakimQuery : IRequest<GetByIdKullaniciTakimResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdKullaniciTakimQueryHandler : IRequestHandler<GetByIdKullaniciTakimQuery, GetByIdKullaniciTakimResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKullaniciTakimRepository _kullaniciTakimRepository;
        private readonly KullaniciTakimBusinessRules _kullaniciTakimBusinessRules;

        public GetByIdKullaniciTakimQueryHandler(IMapper mapper, IKullaniciTakimRepository kullaniciTakimRepository, KullaniciTakimBusinessRules kullaniciTakimBusinessRules)
        {
            _mapper = mapper;
            _kullaniciTakimRepository = kullaniciTakimRepository;
            _kullaniciTakimBusinessRules = kullaniciTakimBusinessRules;
        }

        public async Task<GetByIdKullaniciTakimResponse> Handle(GetByIdKullaniciTakimQuery request, CancellationToken cancellationToken)
        {
            KullaniciTakim? kullaniciTakim = await _kullaniciTakimRepository.GetAsync(predicate: kt => kt.Id == request.Id, cancellationToken: cancellationToken);
            await _kullaniciTakimBusinessRules.KullaniciTakimShouldExistWhenSelected(kullaniciTakim);

            GetByIdKullaniciTakimResponse response = _mapper.Map<GetByIdKullaniciTakimResponse>(kullaniciTakim);
            return response;
        }
    }
}