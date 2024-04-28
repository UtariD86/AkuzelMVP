using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.IlanListes;

public interface IIlanListeService
{
    Task<IlanListe?> GetAsync(
        Expression<Func<IlanListe, bool>> predicate,
        Func<IQueryable<IlanListe>, IIncludableQueryable<IlanListe, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<IlanListe>?> GetListAsync(
        Expression<Func<IlanListe, bool>>? predicate = null,
        Func<IQueryable<IlanListe>, IOrderedQueryable<IlanListe>>? orderBy = null,
        Func<IQueryable<IlanListe>, IIncludableQueryable<IlanListe, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IlanListe> AddAsync(IlanListe ilanListe);
    Task<IlanListe> UpdateAsync(IlanListe ilanListe);
    Task<IlanListe> DeleteAsync(IlanListe ilanListe, bool permanent = false);
}
