using AutoMapper;
using ProjetoExemplo.Aplicacao.ModelosLeitura;
using ProjetoExemplo.Dominio.Modelos;

namespace ProjetoExemplo.Aplicacao.AutoMapper
{
    public class PerfilMapeamentoDominioParaModelo : Profile
    {
        public PerfilMapeamentoDominioParaModelo()
        {
            CreateMap<Cliente, ClienteModeloLeitura>();
        }
    }
}
