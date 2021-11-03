using System;
using Microsoft.Extensions.DependencyInjection;
using MovimentosManuais.Domain;
using MovimentosManuais.Application.Mappers;
using AutoMapper;
using MovimentosManuais.Application.Services;

namespace MovimentosManuais.Application
{
    public static class ApplicationServiceCollection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            if(services == null)
                throw new ArgumentNullException(nameof(services));

            //Instâncias das interfaces e implementações
            services.AddTransient<IMovimentacoesManuais, MovimentacoesManuais>();
            services.AddTransient<IProdutos, Produtos>();
            services.AddTransient<IProdutosCosif, ProdutosCosif>();
            services.AddAutoMapper(typeof(AutoMapperProfiles));
            
            return services;
        }
    }
}