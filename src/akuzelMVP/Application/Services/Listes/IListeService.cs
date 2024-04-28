using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Listes;

public interface IListeService
{
    Task<Liste?> GetAsync(
        Expression<Func<Liste, bool>> predicate,
        Func<IQueryable<Liste>, IIncludableQueryable<Liste, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Liste>?> GetListAsync(
        Expression<Func<Liste, bool>>? predicate = null,
        Func<IQueryable<Liste>, IOrderedQueryable<Liste>>? orderBy = null,
        Func<IQueryable<Liste>, IIncludableQueryable<Liste, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Liste> AddAsync(Liste liste);
    Task<Liste> UpdateAsync(Liste liste);
    Task<Liste> DeleteAsync(Liste liste, bool permanent = false);
}
