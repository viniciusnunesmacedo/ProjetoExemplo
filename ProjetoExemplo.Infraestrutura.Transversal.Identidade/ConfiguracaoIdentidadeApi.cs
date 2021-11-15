using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoExemplo.Infraestrutura.Transversal.Identidade.Seguranca;
using ProjetoExemplo.Infraestrutura.Transversal.Identidade.Seguranca.Jwt;

namespace ProjetoExemplo.Infraestrutura.Transversal.Identidade
{
    public static class ConfiguracaoIdentidadeApi
    {
        public static void AdicionarConfiguracaoIdentidadeApi(this IServiceCollection servicos, IConfiguration configuracoes)
        {
            // Default EF Context for Identity (inside of the NetDevPack.Identity)
            servicos.AddIdentityEntityFrameworkContextConfiguration(options =>
                options.UseSqlServer(configuracoes.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("ProjetoExemplo.Infraestrutura.Transversal.Identidade")));

            // Default Identity configuration from NetDevPack.Identity
            servicos.AdicionarConfiguracaoIdentidade();

            // Default JWT configuration from NetDevPack.Identity
            servicos.AddJwtConfiguration(configuracoes, "AppSettings");
        }
    }
}
