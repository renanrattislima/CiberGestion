using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CiberGestion.Dominio.Contexto;
using CiberGestion.Dominio.Entidade;
using CiberGestion.Dominio.Interface;
using CiberGestion.Dominio.Util;

namespace CiberGestion.Dominio.Repositorio
{
    public class RepositorioAdministrador : IAdministrador
    {
        private readonly EFDbContexto _db = new EFDbContexto();


        public void Dispose()
        {
            _db.Dispose();
        }

      
        public List<Usuario> Listar(int idUsuario)
        {
            var retorno = _db.Database.SqlQuery<Usuario>("SP_UsuarioTelefoneLista @idUsuario"
                ,idUsuario != 0 ? new SqlParameter("idUsuario", idUsuario) : new SqlParameter("idUsuario", DBNull.Value)
            ).ToList();

            return retorno;
        }

        public RetornoPadrao Excluir(Usuario user)
        {
            var retorno = _db.Database.SqlQuery<RetornoPadrao>("SP_UsuarioTelefoneExclui @idUsuario"
                , new SqlParameter("idUsuario", user.idUsuario)).FirstOrDefault();

            return retorno;
        }

        public RetornoPadrao CadastrarAlterar(Usuario user)
        {
            var retorno = _db.Database.SqlQuery<RetornoPadrao>("SP_UsuarioTelefoneCadastro @idUsuario,@dsNome,@dsTelefone,@dsTipoTelefone"
                , new SqlParameter("idUsuario", user.idUsuario)
                , new SqlParameter("dsNome", user.dsNome)
                , new SqlParameter("dsTelefone", user.dsTelefone)
                , new SqlParameter("dsTipoTelefone", user.dsTipoTelefone)
            ).FirstOrDefault();

            return retorno;
        }




    }
}
