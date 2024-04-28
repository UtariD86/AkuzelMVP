using Application.Features.KullaniciAyars.Constants;
using Application.Features.KullaniciAyars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.KullaniciAyars.Constants.KullaniciAyarsOperationClaims;

namespace Application.Features.KullaniciAyars.Queries.GetById;

public class GetByIdKullaniciAyarQuery : IRequest<GetByIdKullaniciAyarResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdKullaniciAyarQueryHandler : IRequestHandler<GetByIdKullaniciAyarQuery, GetByIdKullaniciAyarResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKullaniciAyarRepository _kullaniciAyarRepository;
        private readonly KullaniciAyarBusinessRules _kullaniciAyarBusinessRules;

        public GetByIdKullaniciAyarQueryHandler(IMapper mapper, IKullaniciAyarRepository kullaniciAyarRepository, KullaniciAyarBusinessRules kullaniciAyarBusinessRules)
        {
            _mapper = mapper;
            _kullaniciAyarRepository = kullaniciAyarRepository;
            _kullaniciAyarBusinessRules = kullaniciAyarBusinessRules;
        }

        public async Task<GetByIdKullaniciAyarResponse> Handle(GetByIdKullaniciAyarQuery request, CancellationToken cancellationToken)
        {
            KullaniciAyar? kullaniciAyar = await _kullaniciAyarRepository.GetAsync(predicate: ka => ka.Id == request.Id, cancellationToken: cancellationToken);
            await _kullaniciAyarBusinessRules.KullaniciAyarShouldExistWhenSelected(kullaniciAyar);

            GetByIdKullaniciAyarResponse response = _mapper.Map<GetByIdKullaniciAyarResponse>(kullaniciAyar);
            return response;
        }
    }
}