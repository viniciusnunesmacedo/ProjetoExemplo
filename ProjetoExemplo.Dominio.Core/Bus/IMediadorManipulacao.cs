using FluentValidation.Results;
using ProjetoExemplo.Dominio.Core.Comandos;
using ProjetoExemplo.Dominio.Core.Eventos;
using System.Threading.Tasks;

namespace ProjetoExemplo.Dominio.Core.Bus
{
    public interface IMediadorManipulacao
    {
        Task GerarEvento<T>(T evento) where T : Evento;
        Task<ValidationResult> EnviarComando<T>(T comando) where T : Comando;
    }
}
