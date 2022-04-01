using Data.DataContext;
using Data.Repositories;
using Domain.Interfaces;
using Domain.Notificacoes;
using Domain.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Configuracao
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ContextoDados>();
            services.AddScoped<ILeituristaRepository, LeituristaRepository>();
            services.AddScoped<ILeituristaService, LeituristaService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IOcorrenciaRepository, OcorrenciaRepository>();
            services.AddScoped<IOcorrenciaService, OcorrenciaService>();
            services.AddScoped<ILeituraRepository, LeituraRepository>();
            services.AddScoped<ILeituraService, LeituraService>();
            services.AddScoped<INotificacao, Notificar>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            return services;
        }
    }
}