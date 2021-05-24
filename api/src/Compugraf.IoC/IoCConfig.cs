using Microsoft.Extensions.DependencyInjection;
using Compugraf.Dados.Contextos;
using Compugraf.Dados.Repositorios;
using Compugraf.Dominio.Repositorios;

namespace Compugraf.IoC
{
    public class IoCConfig
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddDbContext<EfContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPessoaRepositorio, PessoaRepositorio>();
        }
    }
}
