using Microsoft.Extensions.DependencyInjection;
using ProjetoExemplo.Consulta.AutoMapper;
using System;

namespace ProjetoExemplo.Servicos.Api.Leitura.Configuracoes
{
    public static class AutoMapperConfig
    {
        public static void AdicionarConfiguracaoAutoMapper(this IServiceCollection servicos)
        {
            if (servicos == null) throw new ArgumentNullException(nameof(servicos));

            servicos.AddAutoMapper(typeof(PerfilMapeamentoDominioParaModelo));
        }
    }
}
