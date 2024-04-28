using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Siparis;

public interface ISiparisService
{
    Task<Domain.Entities.Siparis?> GetAsync(
        Expression<Func<Domain.Entities.Siparis, bool>> predicate,
        Func<IQueryable<Domain.Entities.Siparis>, IIncludableQueryable<Domain.Entities.Siparis, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Domain.Entities.Siparis>?> GetListAsync(
        Expression<Func<Domain.Entities.Siparis, bool>>? predicate = null,
        Func<IQueryable<Domain.Entities.Siparis>, IOrderedQueryable<Domain.Entities.Siparis>>? orderBy = null,
        Func<IQueryable<Domain.Entities.Siparis>, IIncludableQueryable<Domain.Entities.Siparis, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Domain.Entities.Siparis> AddAsync(Domain.Entities.Siparis siparis);
    Task<Domain.Entities.Siparis> UpdateAsync(Domain.Entities.Siparis siparis);
    Task<Domain.Entities.Siparis> DeleteAsync(Domain.Entities.Siparis siparis, bool permanent = false);
}
