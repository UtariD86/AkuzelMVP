using Application.Features.KullaniciTakims.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.KullaniciTakims;

public class KullaniciTakimManager : IKullaniciTakimService
{
    private readonly IKullaniciTakimRepository _kullaniciTakimRepository;
    private readonly KullaniciTakimBusinessRules _kullaniciTakimBusinessRules;

    public KullaniciTakimManager(IKullaniciTakimRepository kullaniciTakimRepository, KullaniciTakimBusinessRules kullaniciTakimBusinessRules)
    {
        _kullaniciTakimRepository = kullaniciTakimRepository;
        _kullaniciTakimBusinessRules = kullaniciTakimBusinessRules;
    }

    public async Task<KullaniciTakim?> GetAsync(
        Expression<Func<KullaniciTakim, bool>> predicate,
        Func<IQueryable<KullaniciTakim>, IIncludableQueryable<KullaniciTakim, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        KullaniciTakim? kullaniciTakim = await _kullaniciTakimRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return kullaniciTakim;
    }

    public async Task<IPaginate<KullaniciTakim>?> GetListAsync(
        Expression<Func<KullaniciTakim, bool>>? predicate = null,
        Func<IQueryable<KullaniciTakim>, IOrderedQueryable<KullaniciTakim>>? orderBy = null,
        Func<IQueryable<KullaniciTakim>, IIncludableQueryable<KullaniciTakim, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<KullaniciTakim> kullaniciTakimList = await _kullaniciTakimRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return kullaniciTakimList;
    }

    public async Task<KullaniciTakim> AddAsync(KullaniciTakim kullaniciTakim)
    {
        KullaniciTakim addedKullaniciTakim = await _kullaniciTakimRepository.AddAsync(kullaniciTakim);

        return addedKullaniciTakim;
    }

    public async Task<KullaniciTakim> UpdateAsync(KullaniciTakim kullaniciTakim)
    {
        KullaniciTakim updatedKullaniciTakim = await _kullaniciTakimRepository.UpdateAsync(kullaniciTakim);

        return updatedKullaniciTakim;
    }

    public async Task<KullaniciTakim> DeleteAsync(KullaniciTakim kullaniciTakim, bool permanent = false)
    {
        KullaniciTakim deletedKullaniciTakim = await _kullaniciTakimRepository.DeleteAsync(kullaniciTakim);

        return deletedKullaniciTakim;
    }
}
