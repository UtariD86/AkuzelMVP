using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Persistence.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseInMemoryDatabase("BaseDb"));
        services.AddDbMigrationApplier(buildServices => buildServices.GetRequiredService<BaseDbContext>());

        services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

        services.AddScoped<IBakiyeGecmisiRepository, BakiyeGecmisiRepository>();
        services.AddScoped<IBankaHesapRepository, BankaHesapRepository>();
        services.AddScoped<IBildirimRepository, BildirimRepository>();
        services.AddScoped<IDegerlendirmeRepository, DegerlendirmeRepository>();
        services.AddScoped<IIlanRepository, IlanRepository>();
        services.AddScoped<IIlanListeRepository, IlanListeRepository>();
        services.AddScoped<IKullaniciAyarRepository, KullaniciAyarRepository>();
        services.AddScoped<IKullaniciBildirimRepository, KullaniciBildirimRepository>();
        services.AddScoped<IKullaniciTakimRepository, KullaniciTakimRepository>();
        services.AddScoped<IKuponRepository, KuponRepository>();
        services.AddScoped<IListeRepository, ListeRepository>();
        services.AddScoped<IListeVeriRepository, ListeVeriRepository>();
        services.AddScoped<IMedyaRepository, MedyaRepository>();
        services.AddScoped<IMesajRepository, MesajRepository>();
        services.AddScoped<IMesajEkRepository, MesajEkRepository>();
        return services;
    }
}
