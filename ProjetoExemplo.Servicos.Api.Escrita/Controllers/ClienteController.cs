using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoExemplo.Aplicacao.Interfaces;
using ProjetoExemplo.Aplicacao.Modelos;
using System;
using System.Threading.Tasks;

namespace ProjetoExemplo.Servicos.Api.Escrita.Controllers
{
    [Authorize]
    public class ClienteController : ApiController
    {
        private readonly IClienteAplicacaoServico _clienteAplicacaoServico;

        public ClienteController(IClienteAplicacaoServico clienteAplicacaoServico)
        {
            _clienteAplicacaoServico = clienteAplicacaoServico;
        }

        //[CustomAuthorize("Customers", "Write")]
        [HttpPost("clientes")]
        public async Task<IActionResult> Post([FromBody] ClienteModelo clienteModelo)
        {
            return !ModelState.IsValid ? RespostaCustomizada(ModelState) : RespostaCustomizada(await _clienteAplicacaoServico.Registrar(clienteModelo));
        }

        //[CustomAuthorize("Customers", "Write")]
        [HttpPut("clientes")]
        public async Task<IActionResult> Put([FromBody] ClienteModelo clienteModelo)
        {
            return !ModelState.IsValid ? RespostaCustomizada(ModelState) : RespostaCustomizada(await _clienteAplicacaoServico.Atualizar(clienteModelo));
        }

        //[CustomAuthorize("Customers", "Remove")]
        [HttpDelete("clientes/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return RespostaCustomizada(await _clienteAplicacaoServico.Excluir(id));
        }
    }
}
