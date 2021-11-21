using Microsoft.EntityFrameworkCore;
using ProjetoExemplo.Dominio.Interfaces.Escrita;
using ProjetoExemplo.Dominio.Interfaces.Base;
using ProjetoExemplo.Dominio.Modelos;
using ProjetoExemplo.Infraestrutura.Dados.Escrita.Contextos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoExemplo.Infraestrutura.Dados.Escrita.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        protected readonly ProjetoExemploContexto _contexto;
        protected readonly DbSet<Produto> DbSet;

        public ProdutoRepositorio(ProjetoExemploContexto contexto)
        {
            _contexto = contexto;
            DbSet = _contexto.Set<Produto>();
        }

        public IUnidadeTrabalho UnidadeTrabalho => _contexto;

        public void Adicionar(Produto produto)
        {
            DbSet.Add(produto);
        }

        public void Atualizar(Produto produto)
        {
            DbSet.Update(produto);
        }

        public void Excluir(Produto produto)
        {
            DbSet.Remove(produto);
        }

        public async Task<Produto> ObterPorDescricao(string descricao)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(m => m.Descricao == descricao);
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
