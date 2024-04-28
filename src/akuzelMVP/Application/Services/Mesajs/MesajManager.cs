using Application.Features.Mesajs.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Mesajs;

public class MesajManager : IMesajService
{
    private readonly IMesajRepository _mesajRepository;
    private readonly MesajBusinessRules _mesajBusinessRules;

    public MesajManager(IMesajRepository mesajRepository, MesajBusinessRules mesajBusinessRules)
    {
        _mesajRepository = mesajRepository;
        _mesajBusinessRules = mesajBusinessRules;
    }

    public async Task<Mesaj?> GetAsync(
        Expression<Func<Mesaj, bool>> predicate,
        Func<IQueryable<Mesaj>, IIncludableQueryable<Mesaj, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Mesaj? mesaj = await _mesajRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return mesaj;
    }

    public async Task<IPaginate<Mesaj>?> GetListAsync(
        Expression<Func<Mesaj, bool>>? predicate = null,
        Func<IQueryable<Mesaj>, IOrderedQueryable<Mesaj>>? orderBy = null,
        Func<IQueryable<Mesaj>, IIncludableQueryable<Mesaj, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Mesaj> mesajList = await _mesajRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return mesajList;
    }

    public async Task<Mesaj> AddAsync(Mesaj mesaj)
    {
        Mesaj addedMesaj = await _mesajRepository.AddAsync(mesaj);

        return addedMesaj;
    }

    public async Task<Mesaj> UpdateAsync(Mesaj mesaj)
    {
        Mesaj updatedMesaj = await _mesajRepository.UpdateAsync(mesaj);

        return updatedMesaj;
    }

    public async Task<Mesaj> DeleteAsync(Mesaj mesaj, bool permanent = false)
    {
        Mesaj deletedMesaj = await _mesajRepository.DeleteAsync(mesaj);

        return deletedMesaj;
    }
}
