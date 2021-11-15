using Microsoft.Extensions.DependencyInjection;
using ProjetoExemplo.Aplicacao.AutoMapper;
using System;

namespace ProjetoExemplo.Servicos.Api.Configuracoes
{
    public static class AutoMapperConfig
    {
        public static void AdicionarConfiguracaoAutoMapper(this IServiceCollection servicos)
        {
            if (servicos == null) throw new ArgumentNullException(nameof(servicos));

            servicos.AddAutoMapper(typeof(PerfilMapeamentoDominioParaModelo), typeof(PerfilMapeamentoModeloParaDominio));
        }
    }
}
