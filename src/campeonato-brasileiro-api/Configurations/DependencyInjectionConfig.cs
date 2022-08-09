using campeonato_brasileiro_business.Interfaces;
using campeonato_brasileiro_business.Notificacoes;
using campeonato_brasileiro_business.Services;
using campeonato_brasileiro_data.Contexts;
using campeonato_brasileiro_data.Repositories;

namespace campeonato_brasileiro_api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<CampeonatoBrasileiroDbContext>();
            services.AddScoped<INotificador, Notificador>();
            
            services.AddScoped<ITorneioService, TorneioService>();
            services.AddScoped<ITimeService, TimeService>();
            services.AddScoped<IJogadorService, JogadorService>();
            services.AddScoped<ITransferenciaService, TransferenciaService>();
            services.AddScoped<IPartidaService, PartidaService>();

            services.AddScoped<ITorneioRepository, TorneioRepository>();
            services.AddScoped<ITimeRepository, TimeRepository>();
            services.AddScoped<IJogadorRepository, JogadorRepository>();
            services.AddScoped<ITransferenciaRepository, TransferenciaRepository>();
            services.AddScoped<IPartidaRepository, PartidaRepository>();
            services.AddScoped<IEventoRepository, EventoRepository>();

            return services;
        }
    }
}
