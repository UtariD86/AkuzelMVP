using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Ilans;

public interface IIlanService
{
    Task<Ilan?> GetAsync(
        Expression<Func<Ilan, bool>> predicate,
        Func<IQueryable<Ilan>, IIncludableQueryable<Ilan, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Ilan>?> GetListAsync(
        Expression<Func<Ilan, bool>>? predicate = null,
        Func<IQueryable<Ilan>, IOrderedQueryable<Ilan>>? orderBy = null,
        Func<IQueryable<Ilan>, IIncludableQueryable<Ilan, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Ilan> AddAsync(Ilan ilan);
    Task<Ilan> UpdateAsync(Ilan ilan);
    Task<Ilan> DeleteAsync(Ilan ilan, bool permanent = false);
}
