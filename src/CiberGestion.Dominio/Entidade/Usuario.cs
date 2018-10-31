using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiberGestion.Dominio.Entidade
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string dsNome { get; set; }
        public string dsTelefone { get; set; }
        public string dsTipoTelefone { get; set; }
        public DateTime dtCadastro { get; set; }
        public DateTime? dtAlteracao { get; set; }
        public bool btAtivo { get; set; }
    }
}
