using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Medyas;

public interface IMedyaService
{
    Task<Medya?> GetAsync(
        Expression<Func<Medya, bool>> predicate,
        Func<IQueryable<Medya>, IIncludableQueryable<Medya, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Medya>?> GetListAsync(
        Expression<Func<Medya, bool>>? predicate = null,
        Func<IQueryable<Medya>, IOrderedQueryable<Medya>>? orderBy = null,
        Func<IQueryable<Medya>, IIncludableQueryable<Medya, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Medya> AddAsync(Medya medya);
    Task<Medya> UpdateAsync(Medya medya);
    Task<Medya> DeleteAsync(Medya medya, bool permanent = false);
}
