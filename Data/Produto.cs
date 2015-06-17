using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class Produto
    {

        public int IdProduto { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public Double Valor { get; set; }
        public int QntdEstoque { get; set; }
        
        public Produto()
        {

        }

    }
}
