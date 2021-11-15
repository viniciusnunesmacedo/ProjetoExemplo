using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoExemplo.Infraestrutura.Transversal.Identidade.Seguranca;
using System;

namespace ProjetoExemplo.Infraestrutura.Transversal.Identidade
{
    public static class ConfiguracaoIdentidadeAplicacaoWeb
    {
        public static void AdicionarConfiguracaoIdentidadeAplicacaoWeb(this IServiceCollection services, IConfiguration configuration)
        {
            // Default EF Context for Identity (inside of the NetDevPack.Identity)
            // https://github.com/NetDevPack/Security.Identity
            services.AddIdentityEntityFrameworkContextConfiguration(options =>
                SqlServerDbContextOptionsExtensions.UseSqlServer(options, configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("ProjetoExemplo.Infraestrutura.Transversal.Identidade")));

            // Default Identity configuration from NetDevPack.Identity
            // https://github.com/NetDevPack/Security.Identity
            services.AdicionarConfiguracaoIdentidade();
        }
    }
}
