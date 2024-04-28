using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Takims;

public interface ITakimService
{
    Task<Takim?> GetAsync(
        Expression<Func<Takim, bool>> predicate,
        Func<IQueryable<Takim>, IIncludableQueryable<Takim, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Takim>?> GetListAsync(
        Expression<Func<Takim, bool>>? predicate = null,
        Func<IQueryable<Takim>, IOrderedQueryable<Takim>>? orderBy = null,
        Func<IQueryable<Takim>, IIncludableQueryable<Takim, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Takim> AddAsync(Takim takim);
    Task<Takim> UpdateAsync(Takim takim);
    Task<Takim> DeleteAsync(Takim takim, bool permanent = false);
}
