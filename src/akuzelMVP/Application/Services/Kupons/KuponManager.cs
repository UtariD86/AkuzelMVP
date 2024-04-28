using Application.Features.Kupons.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Kupons;

public class KuponManager : IKuponService
{
    private readonly IKuponRepository _kuponRepository;
    private readonly KuponBusinessRules _kuponBusinessRules;

    public KuponManager(IKuponRepository kuponRepository, KuponBusinessRules kuponBusinessRules)
    {
        _kuponRepository = kuponRepository;
        _kuponBusinessRules = kuponBusinessRules;
    }

    public async Task<Kupon?> GetAsync(
        Expression<Func<Kupon, bool>> predicate,
        Func<IQueryable<Kupon>, IIncludableQueryable<Kupon, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Kupon? kupon = await _kuponRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return kupon;
    }

    public async Task<IPaginate<Kupon>?> GetListAsync(
        Expression<Func<Kupon, bool>>? predicate = null,
        Func<IQueryable<Kupon>, IOrderedQueryable<Kupon>>? orderBy = null,
        Func<IQueryable<Kupon>, IIncludableQueryable<Kupon, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Kupon> kuponList = await _kuponRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return kuponList;
    }

    public async Task<Kupon> AddAsync(Kupon kupon)
    {
        Kupon addedKupon = await _kuponRepository.AddAsync(kupon);

        return addedKupon;
    }

    public async Task<Kupon> UpdateAsync(Kupon kupon)
    {
        Kupon updatedKupon = await _kuponRepository.UpdateAsync(kupon);

        return updatedKupon;
    }

    public async Task<Kupon> DeleteAsync(Kupon kupon, bool permanent = false)
    {
        Kupon deletedKupon = await _kuponRepository.DeleteAsync(kupon);

        return deletedKupon;
    }
}
