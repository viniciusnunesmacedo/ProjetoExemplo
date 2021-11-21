using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProjetoExemplo.Dominio.Core.Bus;
using ProjetoExemplo.Dominio.Core.Eventos;
using ProjetoExemplo.Dominio.Core.Notificacoes;
using ProjetoExemplo.Dominio.Modulos.Gerenciamento.Clientes.Comandos;
using ProjetoExemplo.Dominio.Modulos.Gerenciamento.Clientes.Eventos;
using ProjetoExemplo.Dominio.Modulos.Gerenciamento.Clientes.ManipuladoresComandos;
using ProjetoExemplo.Dominio.Modulos.Gerenciamento.Clientes.ManipuladoresEventos;
using ProjetoExemplo.Dominio.Modulos.Gerenciamento.Produtos.Comandos;
using ProjetoExemplo.Dominio.Modulos.Gerenciamento.Produtos.Eventos;
using ProjetoExemplo.Dominio.Modulos.Gerenciamento.Produtos.ManipuladoresComandos;
using ProjetoExemplo.Dominio.Modulos.Gerenciamento.Produtos.ManipuladoresEventos;
using ProjetoExemplo.Infraestrutura.Tranversal.Bus;

namespace ProjetoExemplo.Infraestrutura.Tranversal.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegistrarServicosEscrita(IServiceCollection servicos)
        {
            // Domain Bus (Mediator)
            servicos.AddScoped<IMediadorManipulacao, EmMemoriaBus>();

            // Application
            servicos.AddScoped<Aplicacao.Interfaces.IClienteAplicacaoServico, Aplicacao.Servicos.ClienteAplicacaoServico>();
            servicos.AddScoped<Aplicacao.Interfaces.IProdutoAplicacaoServico, Aplicacao.Servicos.ProdutoAplicacaoServico>();

            // Domain - Events
            servicos.AddScoped<INotificationHandler<NotificacaoDominio>, ManipuladorNotificacaoDominio>();

            servicos.AddScoped<INotificationHandler<ClienteRegistradoEvento>, ClienteManipuladorEventos>();
            servicos.AddScoped<INotificationHandler<ClienteAtualizadoEvento>, ClienteManipuladorEventos>();
            servicos.AddScoped<INotificationHandler<ClienteExcluidoEvento>, ClienteManipuladorEventos>();

            servicos.AddScoped<INotificationHandler<ProdutoRegistradoEvento>, ProdutoManipuladorEventos>();
            servicos.AddScoped<INotificationHandler<ProdutoAtualizadoEvento>, ProdutoManipuladorEventos>();
            servicos.AddScoped<INotificationHandler<ProdutoExcluidoEvento>, ProdutoManipuladorEventos>();

            // Domain - Commands
            servicos.AddScoped<IRequestHandler<RegistrarNovoClienteComando, ValidationResult>, ClienteManipuladorComando>();
            servicos.AddScoped<IRequestHandler<AtualizarClienteComando, ValidationResult>, ClienteManipuladorComando>();
            servicos.AddScoped<IRequestHandler<ExcluirClienteComando, ValidationResult>, ClienteManipuladorComando>();

            servicos.AddScoped<IRequestHandler<RegistrarNovoProdutoComando, ValidationResult>, ProdutoManipuladorComando>();
            servicos.AddScoped<IRequestHandler<AtualizarProdutoComando, ValidationResult>, ProdutoManipuladorComando>();
            servicos.AddScoped<IRequestHandler<ExcluirProdutoComando, ValidationResult>, ProdutoManipuladorComando>();

            // Infra - Data - Write
            servicos.AddScoped<Dominio.Interfaces.Escrita.IClienteRepositorio, Dados.Escrita.Repositorio.ClienteRepositorio>();
            servicos.AddScoped<Dominio.Interfaces.Escrita.IProdutoRepositorio, Dados.Escrita.Repositorio.ProdutoRepositorio>();
            servicos.AddScoped<Dados.Escrita.Contextos.ProjetoExemploContexto>();

            // Infra - Data EventSourcing - Write
            servicos.AddScoped<Dados.Escrita.Repositorio.FonteEventos.IArmazenamentoEventoRepositorio, Dados.Escrita.Repositorio.FonteEventos.ArmazenamentoEventoRepositorio>();
            servicos.AddScoped<IArmazenamentoEvento, Dados.Escrita.FonteEventos.SqlArmazenamentoEvento>();
            servicos.AddScoped<Dados.Escrita.Contextos.ArmazenamentoEventoSqlContexto>();

            // Infra - Identity
            //servicos.AddScoped<IUsuario, AspNetUser>();
        }

        public static void RegistrarServicosLeitura(IServiceCollection servicos)
        {
            // Domain Bus (Mediator)
            servicos.AddScoped<IMediadorManipulacao, EmMemoriaBus>();

            // Application
            servicos.AddScoped<Consulta.Interfaces.IClienteAplicacaoServico, Consulta.Servicos.ClienteAplicacaoServico>();
            servicos.AddScoped<Consulta.Interfaces.IProdutoAplicacaoServico, Consulta.Servicos.ProdutoAplicacaoServico>();

            // Infra - Data - Read
            servicos.AddScoped<Dominio.Interfaces.Leitura.IClienteRepositorio, Dados.Leitura.Repositorio.ClienteRepositorio>();
            servicos.AddScoped<Dominio.Interfaces.Leitura.IProdutoRepositorio, Dados.Leitura.Repositorio.ProdutoRepositorio>();
            servicos.AddScoped<Dados.Leitura.Contextos.ProjetoExemploContexto>();

            // Infra - Data EventSourcing - Read
            servicos.AddScoped<Dados.Leitura.Repositorio.FonteEventos.IArmazenamentoEventoRepositorio, Dados.Leitura.Repositorio.FonteEventos.ArmazenamentoEventoRepositorio>();
            servicos.AddScoped<IArmazenamentoEvento, Dados.Leitura.FonteEventos.SqlArmazenamentoEvento>();
            servicos.AddScoped<Dados.Leitura.Contextos.ArmazenamentoEventoSqlContexto>();

            // Infra - Identity
            //servicos.AddScoped<IUsuario, AspNetUser>();
        }
    }
}
