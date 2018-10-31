using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiberGestion.Dominio.Entidade
{
    public class RetornoPadrao
    {
        public int id { get; set; }
        public string dsMensagem { get; set; }
        public string dsCodigo { get; set; }

        public string Mensagem { get; set; }
        public bool Sucesso { get; set; }

        public RetornoPadrao()
        {
            id = 0;
            dsMensagem = String.Empty;
            dsCodigo = String.Empty;
            Mensagem = String.Empty;
            Sucesso = false;
        }
    }
}
