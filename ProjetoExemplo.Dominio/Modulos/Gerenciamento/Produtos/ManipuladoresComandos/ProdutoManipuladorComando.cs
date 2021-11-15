using MediatR;
using ProjetoExemplo.Dominio.Base;
using ProjetoExemplo.Dominio.Interfaces;
using ProjetoExemplo.Dominio.Modelos;
using ProjetoExemplo.Dominio.Modulos.Gerenciamento.Produtos.Comandos;
using ProjetoExemplo.Dominio.Modulos.Gerenciamento.Produtos.Eventos;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoExemplo.Dominio.Modulos.Gerenciamento.Produtos.ManipuladoresComandos
{
    public class ProdutoManipuladorComando : ManipuladorComando,
                                             IRequestHandler<RegistrarNovoProdutoComando, ValidationResult>
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoManipuladorComando(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task<ValidationResult> Handle(RegistrarNovoProdutoComando mensagem, 
                                             CancellationToken cancellationToken)
        {
            if (!mensagem.EValido()) return mensagem.ResultadoValidacao;

            var produto = new Produto(Guid.NewGuid(), mensagem.Descricao, mensagem.UnidadeMedida);

            if (await _produtoRepositorio.ObterPorDescricao(produto.Descricao) != null)
            {
                AdicionarErro("O e-mail do cliente já foi recebido.");
                return ResultadoValidacao;
            }

            produto.AdicionarEventoDominio(new ProdutoRegistradoEvento(produto.Id, produto.Nome, produto.Email));

            _produtoRepositorio.Adicionar(produto);

            return await Persistir(_produtoRepositorio.UnidadeTrabalho);
        }
    }
}
