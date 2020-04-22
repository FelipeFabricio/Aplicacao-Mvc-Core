using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using MvcCore.Business.Interfaces;
using MvcCore.Data.Context;
using MvcCore.Data.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;
using static MvcCore.App.Extensions.MoedaAttribute;

namespace MvcCore.App.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencias(this IServiceCollection services)
        {
            services.AddScoped<MyDbContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddSingleton<IValidationAttributeAdapterProvider, MoedaAttributeAdapterProvider>();

            return services;
        }
    }
}
