using CiberGestion.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiberGestion.Dominio.Interface
{
   public interface ILogin :IDisposable
    {
       UsuarioLogin Acessar(string login , string senha , string ip);
    }
}
