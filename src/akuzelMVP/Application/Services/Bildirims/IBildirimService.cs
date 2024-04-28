using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Bildirims;

public interface IBildirimService
{
    Task<Bildirim?> GetAsync(
        Expression<Func<Bildirim, bool>> predicate,
        Func<IQueryable<Bildirim>, IIncludableQueryable<Bildirim, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Bildirim>?> GetListAsync(
        Expression<Func<Bildirim, bool>>? predicate = null,
        Func<IQueryable<Bildirim>, IOrderedQueryable<Bildirim>>? orderBy = null,
        Func<IQueryable<Bildirim>, IIncludableQueryable<Bildirim, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Bildirim> AddAsync(Bildirim bildirim);
    Task<Bildirim> UpdateAsync(Bildirim bildirim);
    Task<Bildirim> DeleteAsync(Bildirim bildirim, bool permanent = false);
}
