using FluentValidation.Results;
using MediatR;
using ProjetoExemplo.Aplicacao.Modulos.Gerenciamento.Clientes.Eventos;
using ProjetoExemplo.Dominio.Interfaces;
using ProjetoExemplo.Dominio.Modelos;
using ProjetoExemplo.Dominio.Modulos.Gerenciamento.Clientes.Comandos;
using ProjetoExemplo.Dominio.Base;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoExemplo.Aplicacao.Comandos.Clientes
{
    public class ClienteManipuladorComando : ManipuladorComando, 
                                             IRequestHandler<RegistrarNovoClienteComando, ValidationResult>,
                                             IRequestHandler<AtualizarClienteComando, ValidationResult>,
                                             IRequestHandler<ExcluirClienteComando, ValidationResult>
    {
        private readonly IRepositorio _clienteRepositorio;

        public ClienteManipuladorComando(IRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public async Task<ValidationResult> Handle(RegistrarNovoClienteComando mensagem, CancellationToken cancellationToken)
        {
            if (!mensagem.EValido()) return mensagem.ResultadoValidacao;

            var cliente = new Cliente(Guid.NewGuid(), mensagem.Nome, mensagem.Email);

            if (await _clienteRepositorio.ObterPorEmail(cliente.Email) != null)
            {
                AdicionarErro("O e-mail do cliente já foi recebido.");
                return ResultadoValidacao;
            }

            cliente.AdicionarEventoDominio(new ClienteRegistradoEvento(cliente.Id, cliente.Nome, cliente.Email));

            _clienteRepositorio.Adicionar(cliente);

            return await Persistir(_clienteRepositorio.UnidadeTrabalho);
        }

        public async Task<ValidationResult> Handle(AtualizarClienteComando mensagem, CancellationToken cancellationToken)
        {
            if (!mensagem.EValido()) return mensagem.ResultadoValidacao;

            var cliente = new Cliente(mensagem.Id, mensagem.Nome, mensagem.Email);
            var clienteExistente = await _clienteRepositorio.ObterPorEmail(cliente.Email);

            if (clienteExistente != null && clienteExistente.Id != cliente.Id)
            {
                if (!clienteExistente.Equals(cliente))
                {
                    AdicionarErro("O e-mail do cliente já foi recebido.");
                    return ResultadoValidacao;
                }
            }

            cliente.AdicionarEventoDominio(new ClienteAtualizadoEvento(cliente.Id, cliente.Nome, cliente.Email));

            _clienteRepositorio.Atualizar(cliente);

            return await Persistir(_clienteRepositorio.UnidadeTrabalho);
        }

        public async Task<ValidationResult> Handle(ExcluirClienteComando mensagem, CancellationToken cancellationToken)
        {
            if (!mensagem.EValido()) return mensagem.ResultadoValidacao;

            var cliente = await _clienteRepositorio.ObterPorId(mensagem.Id);

            if (cliente is null)
            {
                AdicionarErro("O cliente não existe.");
                return ResultadoValidacao;
            }

            cliente.AdicionarEventoDominio(new ClienteExcluidoEvento(cliente.Id));

            _clienteRepositorio.Excluir(cliente);

            return await Persistir(_clienteRepositorio.UnidadeTrabalho);
        }
    }
}
