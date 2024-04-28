using System.Reflection;
using Application.Services.AuthenticatorService;
using Application.Services.AuthService;
using Application.Services.UsersService;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using NArchitecture.Core.Application.Pipelines.Validation;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Abstraction;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Configurations;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Serilog.File;
using NArchitecture.Core.ElasticSearch;
using NArchitecture.Core.ElasticSearch.Models;
using NArchitecture.Core.Localization.Resource.Yaml.DependencyInjection;
using NArchitecture.Core.Mailing;
using NArchitecture.Core.Mailing.MailKit;
using NArchitecture.Core.Security.DependencyInjection;
using NArchitecture.Core.Security.JWT;
using Application.Services.BakiyeGecmisis;
using Application.Services.BankaHesaps;
using Application.Services.Bildirims;
using Application.Services.Degerlendirmes;
using Application.Services.Ilans;
using Application.Services.IlanListes;
using Application.Services.KullaniciAyars;
using Application.Services.KullaniciBildirims;
using Application.Services.KullaniciTakims;
using Application.Services.Kupons;
using Application.Services.Listes;
using Application.Services.ListeVeris;
using Application.Services.Medyas;
using Application.Services.Mesajs;
using Application.Services.MesajEks;
using Application.Services.Portfolyoes;
using Application.Services.Siparis;
using Application.Services.SistemGecmisis;
using Application.Services.Takims;
using Application.Services.Teklifs;
using Application.Services.Tickets;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        MailSettings mailSettings,
        FileLogConfiguration fileLogConfiguration,
        ElasticSearchConfig elasticSearchConfig,
        TokenOptions tokenOptions
    )
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
        });

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddSingleton<IMailService, MailKitMailService>(_ => new MailKitMailService(mailSettings));
        services.AddSingleton<ILogger, SerilogFileLogger>(_ => new SerilogFileLogger(fileLogConfiguration));
        services.AddSingleton<IElasticSearch, ElasticSearchManager>(_ => new ElasticSearchManager(elasticSearchConfig));

        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IAuthenticatorService, AuthenticatorManager>();
        services.AddScoped<IUserService, UserManager>();

        services.AddYamlResourceLocalization();

        services.AddSecurityServices<Guid, int, Guid>(tokenOptions);

        services.AddScoped<IBakiyeGecmisiService, BakiyeGecmisiManager>();
        services.AddScoped<IBankaHesapService, BankaHesapManager>();
        services.AddScoped<IBildirimService, BildirimManager>();
        services.AddScoped<IDegerlendirmeService, DegerlendirmeManager>();
        services.AddScoped<IIlanService, IlanManager>();
        services.AddScoped<IIlanListeService, IlanListeManager>();
        services.AddScoped<IKullaniciAyarService, KullaniciAyarManager>();
        services.AddScoped<IKullaniciBildirimService, KullaniciBildirimManager>();
        services.AddScoped<IKullaniciTakimService, KullaniciTakimManager>();
        services.AddScoped<IKuponService, KuponManager>();
        services.AddScoped<IListeService, ListeManager>();
        services.AddScoped<IListeVeriService, ListeVeriManager>();
        services.AddScoped<IMedyaService, MedyaManager>();
        services.AddScoped<IMesajService, MesajManager>();
        services.AddScoped<IMesajEkService, MesajEkManager>();
        services.AddScoped<IPortfolyoService, PortfolyoManager>();
        services.AddScoped<ISiparisService, SiparisManager>();
        services.AddScoped<ISistemGecmisiService, SistemGecmisiManager>();
        services.AddScoped<ITakimService, TakimManager>();
        services.AddScoped<ITeklifService, TeklifManager>();
        services.AddScoped<ITicketService, TicketManager>();
        return services;
    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (Type? item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
}
