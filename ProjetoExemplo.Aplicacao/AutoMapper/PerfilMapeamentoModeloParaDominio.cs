using AutoMapper;
using ProjetoExemplo.Aplicacao.ModelosEscrita;
using ProjetoExemplo.Dominio.Modulos.Gerenciamento.Clientes.Comandos;

namespace ProjetoExemplo.Aplicacao.AutoMapper
{
    public class PerfilMapeamentoModeloParaDominio : Profile
    {
        public PerfilMapeamentoModeloParaDominio()
        {
            CreateMap<ClienteModeloEscrita, RegistrarNovoClienteComando>()
                .ConstructUsing(c => new RegistrarNovoClienteComando(c.Id, c.Nome, c.Email));
            
            CreateMap<ClienteModeloEscrita, AtualizarClienteComando>()
                .ConstructUsing(c => new AtualizarClienteComando(c.Id, c.Nome, c.Email));
        }
    }   
}