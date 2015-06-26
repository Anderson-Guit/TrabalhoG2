using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class OrdemServico
    {

        public int IdOS { get; set; }
        public int Cliente { get; set; }
        public String Equipamento { get; set; }
        public String Marca { get; set; }
        public String Modelo { get; set; }
        public String NumeroSerie { get; set; }
        public String Defeito { get; set; }
        public String Servico { get; set; }
        public String Local { get; set; }
        public String Observacoes { get; set; }
        public String Status { get; set; }

        public OrdemServico()
        {

        }

    }
}
