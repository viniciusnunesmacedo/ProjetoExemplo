using AutoMapper;
using ProjetoExemplo.Aplicacao.Modelos;
using ProjetoExemplo.Dominio.Modelos;

namespace ProjetoExemplo.Aplicacao.AutoMapper
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
