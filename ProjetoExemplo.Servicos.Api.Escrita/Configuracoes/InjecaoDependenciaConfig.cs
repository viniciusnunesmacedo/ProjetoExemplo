using Microsoft.Extensions.DependencyInjection;
using ProjetoExemplo.Infraestrutura.Tranversal.IoC;
using System;

namespace ProjetoExemplo.Servicos.Api.Escrita.Configuracoes
{
    public static class InjecaoDependenciaConfig
    {
        public static void AdicionarConfiguracaoInjecaoDependencia(this IServiceCollection servicos)
        {
            if (servicos == null) throw new ArgumentNullException(nameof(servicos));

            NativeInjectorBootStrapper.RegistrarServicosEscrita(servicos);
        }
    }
}
