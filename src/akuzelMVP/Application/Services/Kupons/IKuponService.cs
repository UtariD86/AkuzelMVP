using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Kupons;

public interface IKuponService
{
    Task<Kupon?> GetAsync(
        Expression<Func<Kupon, bool>> predicate,
        Func<IQueryable<Kupon>, IIncludableQueryable<Kupon, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Kupon>?> GetListAsync(
        Expression<Func<Kupon, bool>>? predicate = null,
        Func<IQueryable<Kupon>, IOrderedQueryable<Kupon>>? orderBy = null,
        Func<IQueryable<Kupon>, IIncludableQueryable<Kupon, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Kupon> AddAsync(Kupon kupon);
    Task<Kupon> UpdateAsync(Kupon kupon);
    Task<Kupon> DeleteAsync(Kupon kupon, bool permanent = false);
}
