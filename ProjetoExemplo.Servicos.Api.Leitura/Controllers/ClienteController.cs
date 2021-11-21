using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoExemplo.Consulta.Interfaces;
using ProjetoExemplo.Consulta.Modelos;
using ProjetoExemplo.Consulta.NormalizadoresFontesEventos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoExemplo.Servicos.Api.Leitura.Controllers
{
    [Authorize]
    public class ClienteController : ApiController
    {
        private readonly IClienteAplicacaoServico _clienteAplicacaoServico;

        public ClienteController(IClienteAplicacaoServico clienteAplicacaoServico)
        {
            _clienteAplicacaoServico = clienteAplicacaoServico;
        }

        [HttpGet("clientes")]
        public async Task<IEnumerable<ClienteModelo>> Get()
        {
            return await _clienteAplicacaoServico.ObterTodos();
        }

        [HttpGet("clientes/{id:guid}")]
        public async Task<ClienteModelo> Get(Guid id)
        {
            return await _clienteAplicacaoServico.ObterPorId(id);
        }

        [HttpGet("clientes/historico/{id:guid}")]
        public async Task<IList<DadosHistoricoCliente>> History(Guid id)
        {
            return await _clienteAplicacaoServico.ObterTodoHistorico(id);
        }
    }
}
