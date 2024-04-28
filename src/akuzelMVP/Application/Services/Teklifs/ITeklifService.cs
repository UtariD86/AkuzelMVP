using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Teklifs;

public interface ITeklifService
{
    Task<Teklif?> GetAsync(
        Expression<Func<Teklif, bool>> predicate,
        Func<IQueryable<Teklif>, IIncludableQueryable<Teklif, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Teklif>?> GetListAsync(
        Expression<Func<Teklif, bool>>? predicate = null,
        Func<IQueryable<Teklif>, IOrderedQueryable<Teklif>>? orderBy = null,
        Func<IQueryable<Teklif>, IIncludableQueryable<Teklif, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Teklif> AddAsync(Teklif teklif);
    Task<Teklif> UpdateAsync(Teklif teklif);
    Task<Teklif> DeleteAsync(Teklif teklif, bool permanent = false);
}
