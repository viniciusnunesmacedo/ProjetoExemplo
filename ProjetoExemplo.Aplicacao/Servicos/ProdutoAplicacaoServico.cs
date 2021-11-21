using AutoMapper;
using FluentValidation.Results;
using ProjetoExemplo.Aplicacao.Interfaces;
using ProjetoExemplo.Aplicacao.Modelos;
using ProjetoExemplo.Dominio.Core.Bus;
using ProjetoExemplo.Dominio.Modulos.Gerenciamento.Produtos.Comandos;
using System;
using System.Threading.Tasks;

namespace ProjetoExemplo.Aplicacao.Servicos
{
    public class ProdutoAplicacaoServico : IProdutoAplicacaoServico
    {
        private readonly IMapper _mapeador;
        private readonly IMediadorManipulacao _mediador;
        public ProdutoAplicacaoServico(IMapper mapeador,
                                       IMediadorManipulacao mediador)
        {
            _mapeador = mapeador;
            _mediador = mediador;
        }

        public async Task<ValidationResult> Atualizar(ProdutoModelo produtoModelo)
        {
            var comandoAtualizar = _mapeador.Map<AtualizarProdutoComando>(produtoModelo);
            return await _mediador.EnviarComando(comandoAtualizar);
        }

        public async Task<ValidationResult> Excluir(Guid id)
        {
            var comandoExcluir = new ExcluirProdutoComando(id);
            return await _mediador.EnviarComando(comandoExcluir);
        }

        public async Task<ValidationResult> Registrar(ProdutoModelo produtoModelo)
        {
            var comandoRegistrar = _mapeador.Map<RegistrarNovoProdutoComando>(produtoModelo);
            return await _mediador.EnviarComando(comandoRegistrar);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
