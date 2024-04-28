using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.KullaniciAyars;

public interface IKullaniciAyarService
{
    Task<KullaniciAyar?> GetAsync(
        Expression<Func<KullaniciAyar, bool>> predicate,
        Func<IQueryable<KullaniciAyar>, IIncludableQueryable<KullaniciAyar, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<KullaniciAyar>?> GetListAsync(
        Expression<Func<KullaniciAyar, bool>>? predicate = null,
        Func<IQueryable<KullaniciAyar>, IOrderedQueryable<KullaniciAyar>>? orderBy = null,
        Func<IQueryable<KullaniciAyar>, IIncludableQueryable<KullaniciAyar, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<KullaniciAyar> AddAsync(KullaniciAyar kullaniciAyar);
    Task<KullaniciAyar> UpdateAsync(KullaniciAyar kullaniciAyar);
    Task<KullaniciAyar> DeleteAsync(KullaniciAyar kullaniciAyar, bool permanent = false);
}
