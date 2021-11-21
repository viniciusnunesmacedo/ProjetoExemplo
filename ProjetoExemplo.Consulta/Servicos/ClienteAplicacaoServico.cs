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
    public class ClienteAplicacaoServico : IClienteAplicacaoServico
    {
        private readonly IMapper _mapeador;
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IArmazenamentoEventoRepositorio _armazenadorEventoRepositorio;
        
        public ClienteAplicacaoServico(IMapper mapeador,
                                       IClienteRepositorio clienteRepositorio,
                                       IArmazenamentoEventoRepositorio armazenadorEventoRepositorio)
        {
            _mapeador = mapeador;
            _clienteRepositorio = clienteRepositorio;
            _armazenadorEventoRepositorio = armazenadorEventoRepositorio;
        }

        public async Task<IEnumerable<ClienteModelo>> ObterTodos()
        {
            return _mapeador.Map<IEnumerable<ClienteModelo>>(await _clienteRepositorio.ObterTodos());
        }

        public async Task<ClienteModelo> ObterPorId(Guid id)
        {
            return _mapeador.Map<ClienteModelo>(await _clienteRepositorio.ObterPorId(id));
        }

        public async Task<IList<DadosHistoricoCliente>> ObterTodoHistorico(Guid id)
        {
            return HistoricoCliente.ParaJavaScriptHistoricoCliente(await _armazenadorEventoRepositorio.Todos(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
