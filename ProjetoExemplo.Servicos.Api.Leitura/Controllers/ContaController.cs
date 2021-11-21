using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ProjetoExemplo.Infraestrutura.Transversal.Identidade.Seguranca.Jwt;
using ProjetoExemplo.Infraestrutura.Transversal.Identidade.Seguranca.Modelo;
using System.Threading.Tasks;

namespace ProjetoExemplo.Servicos.Api.Leitura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ApiController
    {
        // Exemplo de uma implementação completa
        // https://codewithmukesh.com/blog/user-management-in-aspnet-core-mvc/

        private readonly SignInManager<UsuarioAplicacao> _gerenciadorAutenticacao;
        private readonly UserManager<UsuarioAplicacao> _gerenciadorUsuarios;
        private readonly ConfiguracoesJwtAplicacao _configuracoesJwtAplicacao;

        public ContaController(
            SignInManager<UsuarioAplicacao> gerenciadorAutenticacao,
            UserManager<UsuarioAplicacao> gerenciadorUsuarios,
            IOptions<ConfiguracoesJwtAplicacao> configuracoesJwtAplicacao)
        {
            _gerenciadorUsuarios = gerenciadorUsuarios;
            _gerenciadorAutenticacao = gerenciadorAutenticacao;
            _configuracoesJwtAplicacao = configuracoesJwtAplicacao.Value;
        }

        [HttpPost]
        [Route("registrar")]
        public async Task<ActionResult> Registrar(RegistroUsuario registroUsuario)
        {
            if (!ModelState.IsValid) return RespostaCustomizada(ModelState);

            var usuario = new UsuarioAplicacao
            {
                UserName = registroUsuario.Email,
                Email = registroUsuario.Email,
                EmailConfirmed = true,
                Perfil = "teste"
            };

            var resultado = await _gerenciadorUsuarios.CreateAsync(usuario, registroUsuario.Senha);

            if (resultado.Succeeded)
            {
                return RespostaCustomizada(ObterJwtCompleto(usuario.Email));
            }

            foreach (var erro in resultado.Errors)
            {
                AdicionarErro(erro.Description);
            }

            return RespostaCustomizada();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginUsuario loginUsuario)
        {
            if (!ModelState.IsValid) return RespostaCustomizada(ModelState);

            var result = await _gerenciadorAutenticacao.PasswordSignInAsync(loginUsuario.Email, loginUsuario.Senha, false, true);

            if (result.Succeeded)
            {
                var fullJwt = ObterJwtCompleto(loginUsuario.Email);
                return RespostaCustomizada(fullJwt);
            }

            if (result.IsLockedOut)
            {
                AdicionarErro("Este usuário esta temporariamente bloqueado");
                return RespostaCustomizada();
            }

            AdicionarErro("Usuário e/ou senha incorretos");
            return RespostaCustomizada();
        }

        private string ObterJwtCompleto(string email)
        {
            return new ConstrutorJwt()
                .WithUserManager(_gerenciadorUsuarios)
                .WithJwtSettings(_configuracoesJwtAplicacao)
                .WithEmail(email)
                .WithJwtClaims()
                .WithUserClaims()
                .WithUserRoles()
                .BuildToken();
        }
    }
}
