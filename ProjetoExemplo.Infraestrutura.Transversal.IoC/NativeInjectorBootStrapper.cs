using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProjetoExemplo.Aplicacao.Comandos.Clientes;
using ProjetoExemplo.Aplicacao.Interfaces;
using ProjetoExemplo.Aplicacao.Modulos.Gerenciamento.Clientes.Eventos;
using ProjetoExemplo.Aplicacao.Servicos;
using ProjetoExemplo.Dominio.Core.Bus;
using ProjetoExemplo.Dominio.Core.Eventos;
using ProjetoExemplo.Dominio.Core.Notificacoes;
using ProjetoExemplo.Dominio.Interfaces;
using ProjetoExemplo.Dominio.Modulos.Gerenciamento.Clientes.Comandos;
using ProjetoExemplo.Dominio.Modulos.Gerenciamento.Clientes.ManipuladoresEventos;
using ProjetoExemplo.Infraestrutura.Dados.Contextos;
using ProjetoExemplo.Infraestrutura.Dados.FonteEventos;
using ProjetoExemplo.Infraestrutura.Dados.Repositorio;
using ProjetoExemplo.Infraestrutura.Dados.Repositorio.FonteEventos;
using ProjetoExemplo.Infraestrutura.Tranversal.Bus;

namespace ProjetoExemplo.Infraestrutura.Tranversal.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegistrarServicos(IServiceCollection servicos)
        {
            // Domain Bus (Mediator)
            servicos.AddScoped<IMediadorManipulacao, EmMemoriaBus>();

            // Application
            servicos.AddScoped<IClienteAplicacaoServico, ClienteAplicacaoServico>();

            // Domain - Events
            servicos.AddScoped<INotificationHandler<NotificacaoDominio>, ManipuladorNotificacaoDominio>();
            servicos.AddScoped<INotificationHandler<ClienteRegistradoEvento>, ClienteManipuladorEventos>();
            servicos.AddScoped<INotificationHandler<ClienteAtualizadoEvento>, ClienteManipuladorEventos>();
            servicos.AddScoped<INotificationHandler<ClienteExcluidoEvento>, ClienteManipuladorEventos>();

            // Domain - Commands
            servicos.AddScoped<IRequestHandler<RegistrarNovoClienteComando, ValidationResult>, ClienteManipuladorComando>();
            servicos.AddScoped<IRequestHandler<AtualizarClienteComando, ValidationResult>, ClienteManipuladorComando>();
            servicos.AddScoped<IRequestHandler<ExcluirClienteComando, ValidationResult>, ClienteManipuladorComando>();

            // Infra - Data
            servicos.AddScoped<IRepositorio, ClienteRepositorio>();
            servicos.AddScoped<ProjetoExemploContexto>();

            // Infra - Data EventSourcing
            servicos.AddScoped<IArmazenamentoEventoRepositorio, ArmazenamentoEventoRepositorio>();
            servicos.AddScoped<IArmazenamentoEvento, SqlArmazenamentoEvento>();
            servicos.AddScoped<ArmazenamentoEventoSqlContexto>();

            // Infra - Identity
            //servicos.AddScoped<IUsuario, AspNetUser>();
        }
    }
}
