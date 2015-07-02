using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Agenda
    {

        public int IdAgenda { get; set; }
        public int IdUsuario { get; set; }

        [Display(Name = "Nome do Usuário", Description = "Usuário do Sistema.")]
        
        public String UsuarioNome { get; set; }
        public int IdCliente { get; set; }

        [Display(Name = "Nome do Cliente", Description = "Cliente do Equipamento.")]
        
        public String ClienteNome { get; set; }

        [Display(Name = "Data", Description = "Informe a Data do Agendamento.")]
        [Required(ErrorMessage = "Data é obrigatório")]
        public String Data { get; set; }

        [Display(Name = "Hora", Description = "Informe a Hora do Agendamento.")]
        [Required(ErrorMessage = "Hora é obrigatório")]
        public String Hora { get; set; }

        [Display(Name = "Local", Description = "Informe o Local do Agendamento.")]
        [Required(ErrorMessage = "Local é obrigatório")]
        public String Local { get; set; }

        [Display(Name = "Serviço", Description = "Informe o Serviço do Agendamento.")]
        [Required(ErrorMessage = "Serviço é obrigatório")]
        public String Servico { get; set; }

        [Display(Name = "Observações", Description = "Informe as Observações do Agendamento.")]
        [Required(ErrorMessage = "Observações são obrigatórias")]
        public String Observacoes { get; set; }

        public Agenda()
        {

        }
                
    }
}
