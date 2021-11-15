using Microsoft.EntityFrameworkCore;
using ProjetoExemplo.Dominio.Interfaces;
using ProjetoExemplo.Dominio.Modelos;
using ProjetoExemplo.Infraestrutura.Dados.Contextos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoExemplo.Infraestrutura.Dados.Repositorio
{
    public class ClienteRepositorio : IRepositorio
    {
        protected readonly ProjetoExemploContexto _contexto;
        protected readonly DbSet<Cliente> DbSet;

        public ClienteRepositorio(ProjetoExemploContexto contexto)
        {
            _contexto = contexto;
            DbSet = _contexto.Set<Cliente>();
        }

        public IUnidadeTrabalho UnidadeTrabalho => _contexto;

        public void Adicionar(Cliente cliente)
        {
            DbSet.Add(cliente);
        }

        public void Atualizar(Cliente cliente)
        {
            DbSet.Update(cliente);
        }

        public void Excluir(Cliente cliente)
        {
            DbSet.Remove(cliente);
        }

        public async Task<Cliente> ObterPorEmail(string email)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(m=>m.Email == email);
        }

        public async Task<Cliente> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Cliente>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
