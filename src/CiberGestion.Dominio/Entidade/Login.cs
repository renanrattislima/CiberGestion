using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiberGestion.Dominio.Entidade
{
   public class Login
    {
        public string LoginUser { get; set; }
        public string Senha { get; set; }
        public string Mensagem { get; set; }

        public string ValidaCampos()
        {
            var msg = "Preencha os seguntes campos \n\n";
            var isvalida = true;

            if (string.IsNullOrEmpty(LoginUser))
            {
                msg += " \nLogin\n";
                isvalida = false;
            }

            if (string.IsNullOrEmpty(Senha))
            {
                msg += " \nSenha\n";
                isvalida = false;
            }

            if (!isvalida)
            {
                Mensagem = msg;
                return Mensagem;
            }

            return string.Empty;
        }


   }
}
