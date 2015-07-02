using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Usuario
    {

        public int IdUsuario { get; set; }

        [Display(Name = "Nome", Description = "Informe o Nome do Cliente.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Números e caracteres especiais não são permitidos no nome.")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public String Nome { get; set; }

        [Display(Name = "Senha", Description = "Informe a Senha do Usuário.")]
        [Required(ErrorMessage = "Senha é obrigatório.")]
        public String Senha { get; set; }

        [Display(Name = "Seleção Administrador", Description = "Define Usuário Simples ou Administrador.")]
        public Boolean Adm { get; set; }


        public Usuario()
        {

        }

    }
}
