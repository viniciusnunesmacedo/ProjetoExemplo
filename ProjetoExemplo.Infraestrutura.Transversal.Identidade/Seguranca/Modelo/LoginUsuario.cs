using System.ComponentModel.DataAnnotations;

namespace ProjetoExemplo.Infraestrutura.Transversal.Identidade.Seguranca.Modelo
{
    public class LoginUsuario
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Senha { get; set; }
    }
}
