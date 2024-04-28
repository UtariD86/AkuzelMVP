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

    public async Task<Domain.Entities.Siparis?> GetAsync(
        Expression<Func<Domain.Entities.Siparis, bool>> predicate,
        Func<IQueryable<Domain.Entities.Siparis>, IIncludableQueryable<Domain.Entities.Siparis, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Domain.Entities.Siparis? siparis = await _siparisRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return siparis;
    }

    public async Task<IPaginate<Domain.Entities.Siparis>?> GetListAsync(
        Expression<Func<Domain.Entities.Siparis, bool>>? predicate = null,
        Func<IQueryable<Domain.Entities.Siparis>, IOrderedQueryable<Domain.Entities.Siparis>>? orderBy = null,
        Func<IQueryable<Domain.Entities.Siparis>, IIncludableQueryable<Domain.Entities.Siparis, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Domain.Entities.Siparis> siparisList = await _siparisRepository.GetListAsync(
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

    public async Task<Domain.Entities.Siparis> AddAsync(Domain.Entities.Siparis siparis)
    {
        Domain.Entities.Siparis addedSiparis = await _siparisRepository.AddAsync(siparis);

        return addedSiparis;
    }

    public async Task<Domain.Entities.Siparis> UpdateAsync(Domain.Entities.Siparis siparis)
    {
        Domain.Entities.Siparis updatedSiparis = await _siparisRepository.UpdateAsync(siparis);

        return updatedSiparis;
    }

    public async Task<Domain.Entities.Siparis> DeleteAsync(Domain.Entities.Siparis siparis, bool permanent = false)
    {
        Domain.Entities.Siparis deletedSiparis = await _siparisRepository.DeleteAsync(siparis);

        return deletedSiparis;
    }
}
