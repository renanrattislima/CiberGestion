using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiberGestion.Dominio.Entidade
{
    public class UsuarioAdmin
    {
        public int IdAdministrador { get; set; }

        public string dsNome { get; set; }

        public string dsLogin { get; set; }

        public string dsEmail { get; set; }

        public DateTime dtCadastro { get; set; }

        public bool btAtivo { get; set; }

        public int idTipo { get; set; }

        public string dsPerfil { get; set; }

        public List<Tipo> lt { get; set; }

        public string dsSenha { get; set; }

        public int idAdministradorCadastro { get; set; }

    }

    public class Tipo {
        public int idTipo { get; set;}

        public string dsNome { get;set;}
    }
}
