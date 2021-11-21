using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoExemplo.Infraestrutura.Dados.Escrita.Contextos;
using System;

namespace ProjetoExemplo.Servicos.Api.Escrita.Configuracoes
{
    public static class BancoDadosConfig
    {
        public static void AdicionarConfiguracaoBancoDados(this IServiceCollection servicos, IConfiguration configuracao)
        {
            if (servicos == null) throw new ArgumentNullException(nameof(servicos));

            servicos.AddDbContext<ProjetoExemploContexto>(options =>
                options.UseSqlServer(configuracao.GetConnectionString("DefaultConnection")));

            servicos.AddDbContext<ArmazenamentoEventoSqlContexto>(options =>
                options.UseSqlServer(configuracao.GetConnectionString("DefaultConnection")));
        }
    }
}
