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
    //[Authorize]
    public class ProdutoController : ApiController
    {
        private readonly IProdutoAplicacaoServico _produtoAplicacaoServico;

        public ProdutoController(IProdutoAplicacaoServico produtoAplicacaoServico)
        {
            _produtoAplicacaoServico = produtoAplicacaoServico;
        }

        [AllowAnonymous]
        [HttpGet("produtos")]
        public async Task<IEnumerable<ProdutoModelo>> Get()
        {
            return await _produtoAplicacaoServico.ObterTodos();
        }

        [AllowAnonymous]
        [HttpGet("produtos/{id:guid}")]
        public async Task<ProdutoModelo> Get(Guid id)
        {
            return await _produtoAplicacaoServico.ObterPorId(id);
        }

        [AllowAnonymous]
        [HttpGet("produtos/historico/{id:guid}")]
        public async Task<IList<DadosHistoricoProduto>> History(Guid id)
        {
            return await _produtoAplicacaoServico.ObterTodoHistorico(id);
        }
    }
}
