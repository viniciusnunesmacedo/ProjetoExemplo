using AutoMapper;
using ProjetoExemplo.Consulta.Modelos;
using ProjetoExemplo.Dominio.Modelos;

namespace ProjetoExemplo.Consulta.AutoMapper
{
    public class PerfilMapeamentoDominioParaModelo : Profile
    {
        public PerfilMapeamentoDominioParaModelo()
        {
            CreateMap<Cliente, ClienteModelo>();
            CreateMap<Produto, ProdutoModelo>();
        }
    }
}
