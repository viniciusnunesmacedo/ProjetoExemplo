using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ProjetoExemplo.Infraestrutura.Transversal.Identidade.Seguranca.Usuario
{
    public static class Abstracao
    {
        public static IServiceCollection AdicionarConfiguracaoUsuarioAspNet(this IServiceCollection servicos)
        {
            servicos.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            servicos.AddScoped<IUsuarioAspNet, UsuarioAspNet>();

            return servicos;
        }
    }
}
