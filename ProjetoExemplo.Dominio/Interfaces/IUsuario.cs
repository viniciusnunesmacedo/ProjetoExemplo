using System.Collections.Generic;
using System.Security.Claims;

namespace ProjetoExemplo.Dominio.Interfaces
{
    public interface IUsuario
    {
        //HttpContext GetHttpContext();
        //IEnumerable<Claim> GetUserClaims();
        //string GetUserEmail();
        //Guid GetUserId();
        //bool IsAutenticated();
        //bool IsInRole(string role);

        string Nome { get; }
        bool estaAutenticado();
        IEnumerable<Claim> ObterReivindicacoesIdentidade();
    }
}
