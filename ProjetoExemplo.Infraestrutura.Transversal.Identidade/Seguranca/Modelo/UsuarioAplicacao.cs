using Microsoft.AspNetCore.Identity;


namespace ProjetoExemplo.Infraestrutura.Transversal.Identidade.Seguranca.Modelo
{
    public class UsuarioAplicacao : IdentityUser<string>
    {
        public string Perfil { get; set; }
    }
}
