using System.ComponentModel.DataAnnotations;

namespace ProjetoExemplo.Infraestrutura.Transversal.Identidade.Seguranca.Modelo
{
    public class RegistroUsuario
    {
        [Required]
        [EmailAddress(ErrorMessage = "E-mail não está em um formato válido")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "As senhas estão diferentes")]
        public string ConfirmacaoSenha { get; set; }
    }
}
