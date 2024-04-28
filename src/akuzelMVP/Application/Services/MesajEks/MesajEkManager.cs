using Application.Features.MesajEks.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MesajEks;

public class MesajEkManager : IMesajEkService
{
    private readonly IMesajEkRepository _mesajEkRepository;
    private readonly MesajEkBusinessRules _mesajEkBusinessRules;

    public MesajEkManager(IMesajEkRepository mesajEkRepository, MesajEkBusinessRules mesajEkBusinessRules)
    {
        _mesajEkRepository = mesajEkRepository;
        _mesajEkBusinessRules = mesajEkBusinessRules;
    }

    public async Task<MesajEk?> GetAsync(
        Expression<Func<MesajEk, bool>> predicate,
        Func<IQueryable<MesajEk>, IIncludableQueryable<MesajEk, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        MesajEk? mesajEk = await _mesajEkRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return mesajEk;
    }

    public async Task<IPaginate<MesajEk>?> GetListAsync(
        Expression<Func<MesajEk, bool>>? predicate = null,
        Func<IQueryable<MesajEk>, IOrderedQueryable<MesajEk>>? orderBy = null,
        Func<IQueryable<MesajEk>, IIncludableQueryable<MesajEk, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<MesajEk> mesajEkList = await _mesajEkRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return mesajEkList;
    }

    public async Task<MesajEk> AddAsync(MesajEk mesajEk)
    {
        MesajEk addedMesajEk = await _mesajEkRepository.AddAsync(mesajEk);

        return addedMesajEk;
    }

    public async Task<MesajEk> UpdateAsync(MesajEk mesajEk)
    {
        MesajEk updatedMesajEk = await _mesajEkRepository.UpdateAsync(mesajEk);

        return updatedMesajEk;
    }

    public async Task<MesajEk> DeleteAsync(MesajEk mesajEk, bool permanent = false)
    {
        MesajEk deletedMesajEk = await _mesajEkRepository.DeleteAsync(mesajEk);

        return deletedMesajEk;
    }
}
