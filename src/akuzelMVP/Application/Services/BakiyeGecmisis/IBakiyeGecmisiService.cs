using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BakiyeGecmisis;

public interface IBakiyeGecmisiService
{
    Task<BakiyeGecmisi?> GetAsync(
        Expression<Func<BakiyeGecmisi, bool>> predicate,
        Func<IQueryable<BakiyeGecmisi>, IIncludableQueryable<BakiyeGecmisi, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<BakiyeGecmisi>?> GetListAsync(
        Expression<Func<BakiyeGecmisi, bool>>? predicate = null,
        Func<IQueryable<BakiyeGecmisi>, IOrderedQueryable<BakiyeGecmisi>>? orderBy = null,
        Func<IQueryable<BakiyeGecmisi>, IIncludableQueryable<BakiyeGecmisi, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<BakiyeGecmisi> AddAsync(BakiyeGecmisi bakiyeGecmisi);
    Task<BakiyeGecmisi> UpdateAsync(BakiyeGecmisi bakiyeGecmisi);
    Task<BakiyeGecmisi> DeleteAsync(BakiyeGecmisi bakiyeGecmisi, bool permanent = false);
}
