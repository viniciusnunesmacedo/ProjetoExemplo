using ProjetoExemplo.Dominio.Modelos;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoExemplo.Aplicacao.Modelos
{
    public class ProdutoModelo
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A Descrição é obrigatória")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A Unidade de Medida é obrigatória")]
        [DisplayName("Unidade de Medida")]
        public UnidadeMedida UnidadeMedida { get; set; }
    }
}
