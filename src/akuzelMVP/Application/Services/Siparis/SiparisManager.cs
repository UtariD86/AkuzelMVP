using Application.Features.Siparis.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Siparis;

public class SiparisManager : ISiparisService
{
    private readonly ISiparisRepository _siparisRepository;
    private readonly SiparisBusinessRules _siparisBusinessRules;

    public SiparisManager(ISiparisRepository siparisRepository, SiparisBusinessRules siparisBusinessRules)
    {
        _siparisRepository = siparisRepository;
        _siparisBusinessRules = siparisBusinessRules;
    }

    public async Task<Siparis?> GetAsync(
        Expression<Func<Siparis, bool>> predicate,
        Func<IQueryable<Siparis>, IIncludableQueryable<Siparis, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Siparis? siparis = await _siparisRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return siparis;
    }

    public async Task<IPaginate<Siparis>?> GetListAsync(
        Expression<Func<Siparis, bool>>? predicate = null,
        Func<IQueryable<Siparis>, IOrderedQueryable<Siparis>>? orderBy = null,
        Func<IQueryable<Siparis>, IIncludableQueryable<Siparis, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Siparis> siparisList = await _siparisRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return siparisList;
    }

    public async Task<Siparis> AddAsync(Siparis siparis)
    {
        Siparis addedSiparis = await _siparisRepository.AddAsync(siparis);

        return addedSiparis;
    }

    public async Task<Siparis> UpdateAsync(Siparis siparis)
    {
        Siparis updatedSiparis = await _siparisRepository.UpdateAsync(siparis);

        return updatedSiparis;
    }

    public async Task<Siparis> DeleteAsync(Siparis siparis, bool permanent = false)
    {
        Siparis deletedSiparis = await _siparisRepository.DeleteAsync(siparis);

        return deletedSiparis;
    }
}
