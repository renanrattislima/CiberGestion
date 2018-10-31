using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiberGestion.Dominio.Entidade
{
   public  class Usuarios
    {
       public string Cpf { get; set; }
       public string Nome { get; set; }
       public string Email { get; set; }
       public string Revenda { get; set; }
       public string Status { get; set; }
       public string Acessar { get; set; }
       public int IdUsuario { get; set; }
       public bool BtCatalago { get; set; }

       public Usuarios()
       {
           Cpf = String.Empty;
           Nome = String.Empty;
           Email = String.Empty;
           Revenda = String.Empty;
           Status = String.Empty;
           Acessar = String.Empty;
           IdUsuario = 0;
           BtCatalago = false;
       }


    }
}
