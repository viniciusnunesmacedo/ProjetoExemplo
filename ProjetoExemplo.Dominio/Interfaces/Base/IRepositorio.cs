using System;

namespace ProjetoExemplo.Dominio.Interfaces.Base
{
    public interface IRepositorio<T> : IDisposable where T : IAgregadoRaiz
    {
        IUnidadeTrabalho UnidadeTrabalho { get; }
    }
}
