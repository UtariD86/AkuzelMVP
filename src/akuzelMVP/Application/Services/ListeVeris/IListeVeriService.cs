using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ListeVeris;

public interface IListeVeriService
{
    Task<ListeVeri?> GetAsync(
        Expression<Func<ListeVeri, bool>> predicate,
        Func<IQueryable<ListeVeri>, IIncludableQueryable<ListeVeri, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ListeVeri>?> GetListAsync(
        Expression<Func<ListeVeri, bool>>? predicate = null,
        Func<IQueryable<ListeVeri>, IOrderedQueryable<ListeVeri>>? orderBy = null,
        Func<IQueryable<ListeVeri>, IIncludableQueryable<ListeVeri, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ListeVeri> AddAsync(ListeVeri listeVeri);
    Task<ListeVeri> UpdateAsync(ListeVeri listeVeri);
    Task<ListeVeri> DeleteAsync(ListeVeri listeVeri, bool permanent = false);
}
