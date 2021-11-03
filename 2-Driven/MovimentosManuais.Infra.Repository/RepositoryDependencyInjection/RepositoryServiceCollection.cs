using System;
using Microsoft.Extensions.DependencyInjection;
using MovimentosManuais.Domain;
using MovimentosManuais.Infra.Repository.Repositories;

namespace MovimentosManuais.Infra.Repository
{
    public static class RepositoryServiceCollection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            if(services == null)
                throw new ArgumentNullException(nameof(services));
            
            services.AddTransient<IMovimentacoesManuaisRepository, MovimentacoesManuaisRepository>();
            services.AddTransient<IProdutosRepository, ProdutosRepository>();
            services.AddTransient<IProdutosCosifRepository, ProdutosCosifRepository>();

            return services;
        } 
    }
}