using AutoMapper;
using FluentValidation.Results;
using ProjetoExemplo.Aplicacao.Interfaces;
using ProjetoExemplo.Aplicacao.Modelos;
using ProjetoExemplo.Dominio.Core.Bus;
using ProjetoExemplo.Dominio.Modulos.Gerenciamento.Clientes.Comandos;
using System;
using System.Threading.Tasks;

namespace ProjetoExemplo.Aplicacao.Servicos
{
    public class ClienteAplicacaoServico : IClienteAplicacaoServico
    {
        private readonly IMapper _mapeador;
        private readonly IMediadorManipulacao _mediador;

        public ClienteAplicacaoServico(IMapper mapeador,
                                       IMediadorManipulacao mediador)
        {
            _mapeador = mapeador;
            _mediador = mediador;
        }

        public async Task<ValidationResult> Registrar(ClienteModelo clienteModelo)
        {
            var comandoRegistrar = _mapeador.Map<RegistrarNovoClienteComando>(clienteModelo);
            return await _mediador.EnviarComando(comandoRegistrar);
        }

        public async Task<ValidationResult> Atualizar(ClienteModelo clienteModelo)
        {
            var comandoAtualizar = _mapeador.Map<AtualizarClienteComando>(clienteModelo);
            return await _mediador.EnviarComando(comandoAtualizar);
        }

        public async Task<ValidationResult> Excluir(Guid id)
        {
            var comandoExcluir = new ExcluirClienteComando(id);
            return await _mediador.EnviarComando(comandoExcluir);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }        
    }
}