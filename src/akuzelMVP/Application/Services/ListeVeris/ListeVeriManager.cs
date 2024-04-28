using Application.Features.ListeVeris.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ListeVeris;

public class ListeVeriManager : IListeVeriService
{
    private readonly IListeVeriRepository _listeVeriRepository;
    private readonly ListeVeriBusinessRules _listeVeriBusinessRules;

    public ListeVeriManager(IListeVeriRepository listeVeriRepository, ListeVeriBusinessRules listeVeriBusinessRules)
    {
        _listeVeriRepository = listeVeriRepository;
        _listeVeriBusinessRules = listeVeriBusinessRules;
    }

    public async Task<ListeVeri?> GetAsync(
        Expression<Func<ListeVeri, bool>> predicate,
        Func<IQueryable<ListeVeri>, IIncludableQueryable<ListeVeri, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ListeVeri? listeVeri = await _listeVeriRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return listeVeri;
    }

    public async Task<IPaginate<ListeVeri>?> GetListAsync(
        Expression<Func<ListeVeri, bool>>? predicate = null,
        Func<IQueryable<ListeVeri>, IOrderedQueryable<ListeVeri>>? orderBy = null,
        Func<IQueryable<ListeVeri>, IIncludableQueryable<ListeVeri, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ListeVeri> listeVeriList = await _listeVeriRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return listeVeriList;
    }

    public async Task<ListeVeri> AddAsync(ListeVeri listeVeri)
    {
        ListeVeri addedListeVeri = await _listeVeriRepository.AddAsync(listeVeri);

        return addedListeVeri;
    }

    public async Task<ListeVeri> UpdateAsync(ListeVeri listeVeri)
    {
        ListeVeri updatedListeVeri = await _listeVeriRepository.UpdateAsync(listeVeri);

        return updatedListeVeri;
    }

    public async Task<ListeVeri> DeleteAsync(ListeVeri listeVeri, bool permanent = false)
    {
        ListeVeri deletedListeVeri = await _listeVeriRepository.DeleteAsync(listeVeri);

        return deletedListeVeri;
    }
}
