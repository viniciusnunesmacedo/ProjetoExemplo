using Newtonsoft.Json;
using ProjetoExemplo.Infraestrutura.Transversal.Identidade.Seguranca.Modelo;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjetoExemplo.Testes
{
    public class TestesIdentificacao
    {
        private readonly HttpClient _clienteHttp;

        public TestesIdentificacao()
        {
            _clienteHttp = new HttpClient();
        }

        [Fact]
        public async Task CriarUsuario()
        {
            var url = "https://localhost:5000/api/conta/registrar";

            var usuario = new RegistroUsuario
            {
                Email = Guid.NewGuid().ToString() + "@gmail.com",
                Senha = "123@Mudar",
                ConfirmacaoSenha = "123@Mudar"
            };

            var parametros = JsonConvert.SerializeObject(usuario);
            var httpContent = new StringContent(parametros, Encoding.UTF8, "application/json");

            var response = await _clienteHttp.PostAsync(url, httpContent).ConfigureAwait(false);

            Assert.True(response.StatusCode == HttpStatusCode.OK);
        }

        [Fact]
        public async Task Login()
        {
            // Cria o usuário
            var url = "https://localhost:5000/api/conta/registrar";

            var usuario = new RegistroUsuario
            {
                Email = Guid.NewGuid().ToString() + "@gmail.com",
                Senha = "123@Mudar",
                ConfirmacaoSenha = "123@Mudar"
            };

            var parametros = JsonConvert.SerializeObject(usuario);
            var httpContent = new StringContent(parametros, Encoding.UTF8, "application/json");

            var response = await _clienteHttp.PostAsync(url, httpContent).ConfigureAwait(false);

            Assert.True(response.StatusCode == HttpStatusCode.OK);

            if (response.StatusCode == HttpStatusCode.OK)
            {

                url = "https://localhost:5000/api/conta/login";
                parametros = JsonConvert.SerializeObject(new LoginUsuario
                {
                    Email = usuario.Email,
                    Senha = usuario.Senha
                });
                
                httpContent = new StringContent(parametros, Encoding.UTF8, "application/json");

                response = await _clienteHttp.PostAsync(url, httpContent).ConfigureAwait(false);

                //tokenJwt = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                Assert.True(response.StatusCode == HttpStatusCode.OK);
            }
        }
    }
}
