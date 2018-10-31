using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiberGestion.Dominio.Entidade
{
   public class AdministradorParticipante
    {
       public int IdUsuario { get; set; }
       public string dsNome { get; set; }
       public string dsCPF { get; set; }
       public string StatusEnvioEmail { get; set; }
       public string StatusEnvioSMS { get; set; }

       public string Cargo { get; set; }
       public string Rede { get; set; }
       public string Status { get; set; }

       public AdministradorParticipante()
       {
           IdUsuario = 0;
           dsNome = String.Empty;
           dsCPF = String.Empty;
           StatusEnvioEmail = String.Empty;
           StatusEnvioSMS = String.Empty;
       }

   }
}
