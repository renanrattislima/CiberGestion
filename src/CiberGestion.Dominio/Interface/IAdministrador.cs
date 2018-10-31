using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CiberGestion.Dominio.Entidade;

namespace CiberGestion.Dominio.Interface
{
   public interface IAdministrador :IDisposable
   {
        List<Usuario> Listar(int idUsuario);
        RetornoPadrao Excluir(Usuario user);
        RetornoPadrao CadastrarAlterar(Usuario user);
    }
}
