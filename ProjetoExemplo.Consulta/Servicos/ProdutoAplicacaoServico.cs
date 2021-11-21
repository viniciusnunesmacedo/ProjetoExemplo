using AutoMapper;
using ProjetoExemplo.Consulta.Interfaces;
using ProjetoExemplo.Consulta.Modelos;
using ProjetoExemplo.Consulta.NormalizadoresFontesEventos;
using ProjetoExemplo.Dominio.Interfaces.Leitura;
using ProjetoExemplo.Infraestrutura.Dados.Leitura.Repositorio.FonteEventos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoExemplo.Consulta.Servicos
{
    public class ProdutoAplicacaoServico : IProdutoAplicacaoServico
    {
        private readonly IMapper _mapeador;
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IArmazenamentoEventoRepositorio _armazenadorEventoRepositorio;

        public ProdutoAplicacaoServico(IMapper mapeador,
                                       IProdutoRepositorio produtoRepositorio,
                                       IArmazenamentoEventoRepositorio armazenadorEventoRepositorio)
        {
            _mapeador = mapeador;
            _produtoRepositorio = produtoRepositorio;
            _armazenadorEventoRepositorio = armazenadorEventoRepositorio;
        }

        public async Task<ProdutoModelo> ObterPorId(Guid id)
        {
            return _mapeador.Map<ProdutoModelo>(await _produtoRepositorio.ObterPorId(id));
        }

        public async Task<IList<DadosHistoricoProduto>> ObterTodoHistorico(Guid id)
        {
            return HistoricoProduto.ParaJavaScriptHistoricoProduto(await _armazenadorEventoRepositorio.Todos(id));
        }

        public async Task<IEnumerable<ProdutoModelo>> ObterTodos()
        {
            return _mapeador.Map<IEnumerable<ProdutoModelo>>(await _produtoRepositorio.ObterTodos());
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
