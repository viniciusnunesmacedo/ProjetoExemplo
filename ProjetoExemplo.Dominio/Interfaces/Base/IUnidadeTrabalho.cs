using System.Threading.Tasks;

namespace ProjetoExemplo.Dominio.Interfaces.Base
{
    /// <summary>
    /// Unit of Work
    /// </summary>
    public interface IUnidadeTrabalho
    {
        /// <summary>
        /// Commit
        /// </summary>
        /// <returns></returns>
        Task<bool> Persistir();
    }
}
