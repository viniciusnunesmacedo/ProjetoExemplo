using AutoMapper;
using FluentValidation.Results;
using ProjetoExemplo.Aplicacao.Interfaces;
using ProjetoExemplo.Aplicacao.ModelosEscrita;
using ProjetoExemplo.Aplicacao.ModelosLeitura;
using ProjetoExemplo.Aplicacao.NormalizadoresFontesEventos;
using ProjetoExemplo.Dominio.Core.Bus;
using ProjetoExemplo.Dominio.Interfaces;
using ProjetoExemplo.Dominio.Modulos.Gerenciamento.Clientes.Comandos;
using ProjetoExemplo.Infraestrutura.Dados.Repositorio.FonteEventos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoExemplo.Aplicacao.Servicos
{
    public class ClienteAplicacaoServico : IClienteAplicacaoServico
    {
        private readonly IMapper _mapeador;
        private readonly IRepositorio _clienteRepositorio;
        private readonly IArmazenamentoEventoRepositorio _eventStoreRepository;
        private readonly IMediadorManipulacao _mediador;

        public ClienteAplicacaoServico(IMapper mapper,
                                       IRepositorio clienteRepositorio,
                                       IMediadorManipulacao mediador,
                                       IArmazenamentoEventoRepositorio eventStoreRepository)
        {
            _mapeador = mapper;
            _clienteRepositorio = clienteRepositorio;
            _mediador = mediador;
            _eventStoreRepository = eventStoreRepository;
        }

        public async Task<IEnumerable<ClienteModeloLeitura>> ObterTodos()
        {
            return _mapeador.Map<IEnumerable<ClienteModeloLeitura>>(await _clienteRepositorio.ObterTodos());
        }

        public async Task<ClienteModeloLeitura> ObterPorId(Guid id)
        {
            return _mapeador.Map<ClienteModeloLeitura>(await _clienteRepositorio.ObterPorId(id));
        }

        public async Task<IList<DadosHistoricoCliente>> ObterTodoHistorico(Guid id)
        {
            return HistoricoCliente.ParaJavaScriptHistoricoCliente(await _eventStoreRepository.Todos(id));
        }

        public async Task<ValidationResult> Registrar(ClienteModeloEscrita clienteModeloEscrita)
        {
            var comandoRegistrar = _mapeador.Map<RegistrarNovoClienteComando>(clienteModeloEscrita);
            return await _mediador.EnviarComando(comandoRegistrar);
        }

        public async Task<ValidationResult> Atualizar(ClienteModeloEscrita clienteModeloEscrita)
        {
            var comandoAtualizar = _mapeador.Map<AtualizarClienteComando>(clienteModeloEscrita);
            return await _mediador.EnviarComando(comandoAtualizar);
        }

        public async Task<ValidationResult> Excluir(Guid id)
        {
            var comandoExcluir = _mapeador.Map<ExcluirClienteComando>(id);
            return await _mediador.EnviarComando(comandoExcluir);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }        
    }
}
