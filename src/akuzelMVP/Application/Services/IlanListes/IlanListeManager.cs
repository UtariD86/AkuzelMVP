using Application.Features.IlanListes.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.IlanListes;

public class IlanListeManager : IIlanListeService
{
    private readonly IIlanListeRepository _ilanListeRepository;
    private readonly IlanListeBusinessRules _ilanListeBusinessRules;

    public IlanListeManager(IIlanListeRepository ilanListeRepository, IlanListeBusinessRules ilanListeBusinessRules)
    {
        _ilanListeRepository = ilanListeRepository;
        _ilanListeBusinessRules = ilanListeBusinessRules;
    }

    public async Task<IlanListe?> GetAsync(
        Expression<Func<IlanListe, bool>> predicate,
        Func<IQueryable<IlanListe>, IIncludableQueryable<IlanListe, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IlanListe? ilanListe = await _ilanListeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return ilanListe;
    }

    public async Task<IPaginate<IlanListe>?> GetListAsync(
        Expression<Func<IlanListe, bool>>? predicate = null,
        Func<IQueryable<IlanListe>, IOrderedQueryable<IlanListe>>? orderBy = null,
        Func<IQueryable<IlanListe>, IIncludableQueryable<IlanListe, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<IlanListe> ilanListeList = await _ilanListeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return ilanListeList;
    }

    public async Task<IlanListe> AddAsync(IlanListe ilanListe)
    {
        IlanListe addedIlanListe = await _ilanListeRepository.AddAsync(ilanListe);

        return addedIlanListe;
    }

    public async Task<IlanListe> UpdateAsync(IlanListe ilanListe)
    {
        IlanListe updatedIlanListe = await _ilanListeRepository.UpdateAsync(ilanListe);

        return updatedIlanListe;
    }

    public async Task<IlanListe> DeleteAsync(IlanListe ilanListe, bool permanent = false)
    {
        IlanListe deletedIlanListe = await _ilanListeRepository.DeleteAsync(ilanListe);

        return deletedIlanListe;
    }
}
