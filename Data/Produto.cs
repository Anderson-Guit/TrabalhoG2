using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Produto
    {

        public int IdProduto { get; set; }
        [Display(Name = "Nome", Description = "Informe o Nome do Cliente.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Números e caracteres especiais não são permitidos no nome.")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
       
        public String Nome { get; set; }

        [Display(Name = "Descrição", Description = "Informe a Descrição do Poduto.")]
        [Required(ErrorMessage = "Produto é obrigatório")]
        public String Descricao { get; set; }

        [Display(Name = "Valor", Description = "Informe o Valor do Produto.")]
        [Required(ErrorMessage = "Valor é obrigatório")]
        public Double Valor { get; set; }

        [Display(Name = "Quantidade em Estoque", Description = "Informe a Quantidade de Produtos em Estoque.")]
        [Required(ErrorMessage = "Modelo é obrigatório")]
        public int QntdEstoque { get; set; }
        
        public Produto()
        {

        }

    }
}
