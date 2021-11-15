using System.Collections.Generic;

namespace ProjetoExemplo.Infraestrutura.Transversal.Identidade.Seguranca.Jwt.Modelo
{
    public class UserToken<T>
    {
        public T Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<UserClaim> Claims { get; set; }
    }

    public class UserToken : UserToken<string>
    {

    }
}
