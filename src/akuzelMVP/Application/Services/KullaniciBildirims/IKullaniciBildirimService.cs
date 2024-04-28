using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.KullaniciBildirims;

public interface IKullaniciBildirimService
{
    Task<KullaniciBildirim?> GetAsync(
        Expression<Func<KullaniciBildirim, bool>> predicate,
        Func<IQueryable<KullaniciBildirim>, IIncludableQueryable<KullaniciBildirim, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<KullaniciBildirim>?> GetListAsync(
        Expression<Func<KullaniciBildirim, bool>>? predicate = null,
        Func<IQueryable<KullaniciBildirim>, IOrderedQueryable<KullaniciBildirim>>? orderBy = null,
        Func<IQueryable<KullaniciBildirim>, IIncludableQueryable<KullaniciBildirim, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<KullaniciBildirim> AddAsync(KullaniciBildirim kullaniciBildirim);
    Task<KullaniciBildirim> UpdateAsync(KullaniciBildirim kullaniciBildirim);
    Task<KullaniciBildirim> DeleteAsync(KullaniciBildirim kullaniciBildirim, bool permanent = false);
}
