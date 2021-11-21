using FluentValidation.Results;
using MediatR;
using ProjetoExemplo.Dominio.Base;
using ProjetoExemplo.Dominio.Modelos;
using ProjetoExemplo.Dominio.Modulos.Gerenciamento.Produtos.Comandos;
using ProjetoExemplo.Dominio.Modulos.Gerenciamento.Produtos.Eventos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoExemplo.Dominio.Modulos.Gerenciamento.Produtos.ManipuladoresComandos
{
    public class ProdutoManipuladorComando : ManipuladorComando,
                                             IRequestHandler<RegistrarNovoProdutoComando, ValidationResult>,
                                             IRequestHandler<AtualizarProdutoComando, ValidationResult>,
                                             IRequestHandler<ExcluirProdutoComando, ValidationResult>
    {
        private readonly Interfaces.Escrita.IProdutoRepositorio _produtoRepositorio;

        public ProdutoManipuladorComando(Interfaces.Escrita.IProdutoRepositorio produtoRepositorio)
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
                AdicionarErro("O produto já existe.");
                return ResultadoValidacao;
            }

            produto.AdicionarEventoDominio(new ProdutoRegistradoEvento(produto.Id, produto.Descricao, produto.UnidadeMedida));

            _produtoRepositorio.Adicionar(produto);

            return await Persistir(_produtoRepositorio.UnidadeTrabalho);
        }

        public async Task<ValidationResult> Handle(AtualizarProdutoComando mensagem, CancellationToken cancellationToken)
        {
            if (!mensagem.EValido()) return mensagem.ResultadoValidacao;

            var produto = new Produto(mensagem.Id, mensagem.Descricao, mensagem.UnidadeMedida);
            var produtoExistente = await _produtoRepositorio.ObterPorDescricao(produto.Descricao);

            if (produtoExistente != null && produtoExistente.Id != produto.Id)
            {
                if (!produtoExistente.Equals(produto))
                {
                    AdicionarErro("Produto já existente.");
                    return ResultadoValidacao;
                }
            }

            produto.AdicionarEventoDominio(new ProdutoAtualizadoEvento(produto.Id, produto.Descricao, produto.UnidadeMedida));

            _produtoRepositorio.Atualizar(produto);

            return await Persistir(_produtoRepositorio.UnidadeTrabalho);
        }

        public async Task<ValidationResult> Handle(ExcluirProdutoComando mensagem, CancellationToken cancellationToken)
        {
            if (!mensagem.EValido()) return mensagem.ResultadoValidacao;

            var produto = await _produtoRepositorio.ObterPorId(mensagem.Id);

            if (produto is null)
            {
                AdicionarErro("O produto não existe.");
                return ResultadoValidacao;
            }

            produto.AdicionarEventoDominio(new ProdutoExcluidoEvento(produto.Id));

            _produtoRepositorio.Excluir(produto);

            return await Persistir(_produtoRepositorio.UnidadeTrabalho);
        }
    }
}
