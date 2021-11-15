using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoExemplo.Aplicacao.Interfaces;
using ProjetoExemplo.Aplicacao.ModelosEscrita;
using ProjetoExemplo.Aplicacao.ModelosLeitura;
using ProjetoExemplo.Aplicacao.NormalizadoresFontesEventos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoExemplo.Servicos.Api.Controllers
{
    [Authorize]
    public class ClienteController : ApiController
    {
        private readonly IClienteAplicacaoServico _clienteAplicacaoServico;

        public ClienteController(IClienteAplicacaoServico clienteAplicacaoServico)
        {
            _clienteAplicacaoServico = clienteAplicacaoServico;
        }

        [AllowAnonymous]
        [HttpGet("customer-management")]
        public async Task<IEnumerable<ClienteModeloLeitura>> Get()
        {
            return await _clienteAplicacaoServico.ObterTodos();
        }

        [AllowAnonymous]
        [HttpGet("customer-management/{id:guid}")]
        public async Task<ClienteModeloLeitura> Get(Guid id)
        {
            return await _clienteAplicacaoServico.ObterPorId(id);
        }

        //[CustomAuthorize("Customers", "Write")]
        [HttpPost("customer-management")]
        public async Task<IActionResult> Post([FromBody] ClienteModeloEscrita clienteModeloEscrita)
        {
            return !ModelState.IsValid ? RespostaCustomizada(ModelState) : RespostaCustomizada(await _clienteAplicacaoServico.Registrar(clienteModeloEscrita));
        }

        //[CustomAuthorize("Customers", "Write")]
        [HttpPut("customer-management")]
        public async Task<IActionResult> Put([FromBody] ClienteModeloEscrita clienteModeloEscrita)
        {
            return !ModelState.IsValid ? RespostaCustomizada(ModelState) : RespostaCustomizada(await _clienteAplicacaoServico.Atualizar(clienteModeloEscrita));
        }

        //[CustomAuthorize("Customers", "Remove")]
        [HttpDelete("customer-management")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return RespostaCustomizada(await _clienteAplicacaoServico.Excluir(id));
        }

        [AllowAnonymous]
        [HttpGet("customer-management/history/{id:guid}")]
        public async Task<IList<DadosHistoricoCliente>> History(Guid id)
        {
            return await _clienteAplicacaoServico.ObterTodoHistorico(id);
        }
    }
}
