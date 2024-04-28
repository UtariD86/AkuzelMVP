using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.KullaniciTakims;

public interface IKullaniciTakimService
{
    Task<KullaniciTakim?> GetAsync(
        Expression<Func<KullaniciTakim, bool>> predicate,
        Func<IQueryable<KullaniciTakim>, IIncludableQueryable<KullaniciTakim, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<KullaniciTakim>?> GetListAsync(
        Expression<Func<KullaniciTakim, bool>>? predicate = null,
        Func<IQueryable<KullaniciTakim>, IOrderedQueryable<KullaniciTakim>>? orderBy = null,
        Func<IQueryable<KullaniciTakim>, IIncludableQueryable<KullaniciTakim, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<KullaniciTakim> AddAsync(KullaniciTakim kullaniciTakim);
    Task<KullaniciTakim> UpdateAsync(KullaniciTakim kullaniciTakim);
    Task<KullaniciTakim> DeleteAsync(KullaniciTakim kullaniciTakim, bool permanent = false);
}
