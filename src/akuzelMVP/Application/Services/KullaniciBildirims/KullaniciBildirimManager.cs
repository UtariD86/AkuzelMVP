using Application.Features.KullaniciBildirims.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.KullaniciBildirims;

public class KullaniciBildirimManager : IKullaniciBildirimService
{
    private readonly IKullaniciBildirimRepository _kullaniciBildirimRepository;
    private readonly KullaniciBildirimBusinessRules _kullaniciBildirimBusinessRules;

    public KullaniciBildirimManager(IKullaniciBildirimRepository kullaniciBildirimRepository, KullaniciBildirimBusinessRules kullaniciBildirimBusinessRules)
    {
        _kullaniciBildirimRepository = kullaniciBildirimRepository;
        _kullaniciBildirimBusinessRules = kullaniciBildirimBusinessRules;
    }

    public async Task<KullaniciBildirim?> GetAsync(
        Expression<Func<KullaniciBildirim, bool>> predicate,
        Func<IQueryable<KullaniciBildirim>, IIncludableQueryable<KullaniciBildirim, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        KullaniciBildirim? kullaniciBildirim = await _kullaniciBildirimRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return kullaniciBildirim;
    }

    public async Task<IPaginate<KullaniciBildirim>?> GetListAsync(
        Expression<Func<KullaniciBildirim, bool>>? predicate = null,
        Func<IQueryable<KullaniciBildirim>, IOrderedQueryable<KullaniciBildirim>>? orderBy = null,
        Func<IQueryable<KullaniciBildirim>, IIncludableQueryable<KullaniciBildirim, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<KullaniciBildirim> kullaniciBildirimList = await _kullaniciBildirimRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return kullaniciBildirimList;
    }

    public async Task<KullaniciBildirim> AddAsync(KullaniciBildirim kullaniciBildirim)
    {
        KullaniciBildirim addedKullaniciBildirim = await _kullaniciBildirimRepository.AddAsync(kullaniciBildirim);

        return addedKullaniciBildirim;
    }

    public async Task<KullaniciBildirim> UpdateAsync(KullaniciBildirim kullaniciBildirim)
    {
        KullaniciBildirim updatedKullaniciBildirim = await _kullaniciBildirimRepository.UpdateAsync(kullaniciBildirim);

        return updatedKullaniciBildirim;
    }

    public async Task<KullaniciBildirim> DeleteAsync(KullaniciBildirim kullaniciBildirim, bool permanent = false)
    {
        KullaniciBildirim deletedKullaniciBildirim = await _kullaniciBildirimRepository.DeleteAsync(kullaniciBildirim);

        return deletedKullaniciBildirim;
    }
}
