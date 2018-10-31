using System;

namespace CiberGestion.Dominio.Entidade
{
   public class DropDownList
    {
       public string Valor { get; set; }
       public string Texto { get; set; }

       public DropDownList()
       {
           Valor = String.Empty;
           Texto = String.Empty;
       }
    }
}
