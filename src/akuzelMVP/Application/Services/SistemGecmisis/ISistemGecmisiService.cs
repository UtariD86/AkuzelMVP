using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SistemGecmisis;

public interface ISistemGecmisiService
{
    Task<SistemGecmisi?> GetAsync(
        Expression<Func<SistemGecmisi, bool>> predicate,
        Func<IQueryable<SistemGecmisi>, IIncludableQueryable<SistemGecmisi, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<SistemGecmisi>?> GetListAsync(
        Expression<Func<SistemGecmisi, bool>>? predicate = null,
        Func<IQueryable<SistemGecmisi>, IOrderedQueryable<SistemGecmisi>>? orderBy = null,
        Func<IQueryable<SistemGecmisi>, IIncludableQueryable<SistemGecmisi, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<SistemGecmisi> AddAsync(SistemGecmisi sistemGecmisi);
    Task<SistemGecmisi> UpdateAsync(SistemGecmisi sistemGecmisi);
    Task<SistemGecmisi> DeleteAsync(SistemGecmisi sistemGecmisi, bool permanent = false);
}
