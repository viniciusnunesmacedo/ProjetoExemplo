using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoExemplo.Aplicacao.Interfaces;
using ProjetoExemplo.Aplicacao.Modelos;
using System;
using System.Threading.Tasks;

namespace ProjetoExemplo.Servicos.Api.Escrita.Controllers
{
    [Authorize]
    public class ProdutoController : ApiController
    {
        private readonly IProdutoAplicacaoServico _produtoAplicacaoServico;

        public ProdutoController(IProdutoAplicacaoServico produtoAplicacaoServico)
        {
            _produtoAplicacaoServico = produtoAplicacaoServico;
        }

        //[CustomAuthorize("Customers", "Write")]
        [HttpPost("produtos")]
        public async Task<IActionResult> Post([FromBody] ProdutoModelo produtoModelo)
        {
            return !ModelState.IsValid ? RespostaCustomizada(ModelState) : RespostaCustomizada(await _produtoAplicacaoServico.Registrar(produtoModelo));
        }

        //[CustomAuthorize("Customers", "Write")]
        [HttpPut("produtos")]
        public async Task<IActionResult> Put([FromBody] ProdutoModelo produtoModelo)
        {
            return !ModelState.IsValid ? RespostaCustomizada(ModelState) : RespostaCustomizada(await _produtoAplicacaoServico.Atualizar(produtoModelo));
        }

        //[CustomAuthorize("Customers", "Remove")]
        [HttpDelete("produtos/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return RespostaCustomizada(await _produtoAplicacaoServico.Excluir(id));
        }
    }
}
