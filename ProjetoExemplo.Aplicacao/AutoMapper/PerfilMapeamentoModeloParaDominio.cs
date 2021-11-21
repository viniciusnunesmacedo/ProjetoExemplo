using AutoMapper;
using ProjetoExemplo.Aplicacao.Modelos;
using ProjetoExemplo.Dominio.Modulos.Gerenciamento.Clientes.Comandos;
using ProjetoExemplo.Dominio.Modulos.Gerenciamento.Produtos.Comandos;

namespace ProjetoExemplo.Aplicacao.AutoMapper
{
    public class PerfilMapeamentoModeloParaDominio : Profile
    {
        public PerfilMapeamentoModeloParaDominio()
        {
            CreateMap<ClienteModelo, RegistrarNovoClienteComando>()
                .ConstructUsing(c => new RegistrarNovoClienteComando(c.Id, c.Nome, c.Email));
            
            CreateMap<ClienteModelo, AtualizarClienteComando>()
                .ConstructUsing(c => new AtualizarClienteComando(c.Id, c.Nome, c.Email));

            //CreateMap<ClienteModelo, ExcluirClienteComando>()
            //    .ConstructUsing(c => new ExcluirClienteComando(c.Id));


            CreateMap<ProdutoModelo, RegistrarNovoProdutoComando>()
                .ConstructUsing(c => new RegistrarNovoProdutoComando(c.Id, c.Descricao, c.UnidadeMedida));

            CreateMap<ProdutoModelo, AtualizarProdutoComando>()
                .ConstructUsing(c => new AtualizarProdutoComando(c.Id, c.Descricao, c.UnidadeMedida));

            //CreateMap<ProdutoModelo, ExcluirProdutoComando>()
            //    .ConstructUsing(c => new ExcluirProdutoComando(c.Id));
        }
    }   
}