using Application.Features.KullaniciAyars.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.KullaniciAyars;

public class KullaniciAyarManager : IKullaniciAyarService
{
    private readonly IKullaniciAyarRepository _kullaniciAyarRepository;
    private readonly KullaniciAyarBusinessRules _kullaniciAyarBusinessRules;

    public KullaniciAyarManager(IKullaniciAyarRepository kullaniciAyarRepository, KullaniciAyarBusinessRules kullaniciAyarBusinessRules)
    {
        _kullaniciAyarRepository = kullaniciAyarRepository;
        _kullaniciAyarBusinessRules = kullaniciAyarBusinessRules;
    }

    public async Task<KullaniciAyar?> GetAsync(
        Expression<Func<KullaniciAyar, bool>> predicate,
        Func<IQueryable<KullaniciAyar>, IIncludableQueryable<KullaniciAyar, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        KullaniciAyar? kullaniciAyar = await _kullaniciAyarRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return kullaniciAyar;
    }

    public async Task<IPaginate<KullaniciAyar>?> GetListAsync(
        Expression<Func<KullaniciAyar, bool>>? predicate = null,
        Func<IQueryable<KullaniciAyar>, IOrderedQueryable<KullaniciAyar>>? orderBy = null,
        Func<IQueryable<KullaniciAyar>, IIncludableQueryable<KullaniciAyar, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<KullaniciAyar> kullaniciAyarList = await _kullaniciAyarRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return kullaniciAyarList;
    }

    public async Task<KullaniciAyar> AddAsync(KullaniciAyar kullaniciAyar)
    {
        KullaniciAyar addedKullaniciAyar = await _kullaniciAyarRepository.AddAsync(kullaniciAyar);

        return addedKullaniciAyar;
    }

    public async Task<KullaniciAyar> UpdateAsync(KullaniciAyar kullaniciAyar)
    {
        KullaniciAyar updatedKullaniciAyar = await _kullaniciAyarRepository.UpdateAsync(kullaniciAyar);

        return updatedKullaniciAyar;
    }

    public async Task<KullaniciAyar> DeleteAsync(KullaniciAyar kullaniciAyar, bool permanent = false)
    {
        KullaniciAyar deletedKullaniciAyar = await _kullaniciAyarRepository.DeleteAsync(kullaniciAyar);

        return deletedKullaniciAyar;
    }
}
