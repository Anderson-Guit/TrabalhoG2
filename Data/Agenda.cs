using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Agenda
    {

        public int IdAgenda { get; set; }
        public int IdCliente { get; set; }
        public String ClienteNome { get; set; }
        public int IdUsuario { get; set; }
        public String UsuarioNome { get; set; }
        public String Data { get; set; }
        public String Hora { get; set; }
        public String Local { get; set; }
        public String Servico { get; set; }
        public String Observacoes { get; set; }

        public Agenda()
        {

        }
                
    }
}
