using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Siparis;

public interface ISiparisService
{
    Task<Siparis?> GetAsync(
        Expression<Func<Siparis, bool>> predicate,
        Func<IQueryable<Siparis>, IIncludableQueryable<Siparis, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Siparis>?> GetListAsync(
        Expression<Func<Siparis, bool>>? predicate = null,
        Func<IQueryable<Siparis>, IOrderedQueryable<Siparis>>? orderBy = null,
        Func<IQueryable<Siparis>, IIncludableQueryable<Siparis, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Siparis> AddAsync(Siparis siparis);
    Task<Siparis> UpdateAsync(Siparis siparis);
    Task<Siparis> DeleteAsync(Siparis siparis, bool permanent = false);
}
