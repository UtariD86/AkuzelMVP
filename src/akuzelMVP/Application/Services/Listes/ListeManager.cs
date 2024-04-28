using Application.Features.Listes.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Listes;

public class ListeManager : IListeService
{
    private readonly IListeRepository _listeRepository;
    private readonly ListeBusinessRules _listeBusinessRules;

    public ListeManager(IListeRepository listeRepository, ListeBusinessRules listeBusinessRules)
    {
        _listeRepository = listeRepository;
        _listeBusinessRules = listeBusinessRules;
    }

    public async Task<Liste?> GetAsync(
        Expression<Func<Liste, bool>> predicate,
        Func<IQueryable<Liste>, IIncludableQueryable<Liste, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Liste? liste = await _listeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return liste;
    }

    public async Task<IPaginate<Liste>?> GetListAsync(
        Expression<Func<Liste, bool>>? predicate = null,
        Func<IQueryable<Liste>, IOrderedQueryable<Liste>>? orderBy = null,
        Func<IQueryable<Liste>, IIncludableQueryable<Liste, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Liste> listeList = await _listeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return listeList;
    }

    public async Task<Liste> AddAsync(Liste liste)
    {
        Liste addedListe = await _listeRepository.AddAsync(liste);

        return addedListe;
    }

    public async Task<Liste> UpdateAsync(Liste liste)
    {
        Liste updatedListe = await _listeRepository.UpdateAsync(liste);

        return updatedListe;
    }

    public async Task<Liste> DeleteAsync(Liste liste, bool permanent = false)
    {
        Liste deletedListe = await _listeRepository.DeleteAsync(liste);

        return deletedListe;
    }
}
