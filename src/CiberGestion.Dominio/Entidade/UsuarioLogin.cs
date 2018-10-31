using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiberGestion.Dominio.Entidade
{
    public class UsuarioLogin
    {
        public int idAdministrador { get; set; }
        public string dsNome { get; set; }
        public string dsEmail { get; set; }
        public string dsLogin { get; set; }
        public int idTipo { get; set; }
        public string dsTipo { get; set; }
        public string dsSenha { get; set; }

        public UsuarioLogin()
        {
            idAdministrador = 0;
            dsNome = String.Empty;
            dsEmail = String.Empty;
            dsLogin = String.Empty;
            idTipo = 0;
            dsTipo = String.Empty;
            dsSenha = String.Empty;
        }

    }
}
