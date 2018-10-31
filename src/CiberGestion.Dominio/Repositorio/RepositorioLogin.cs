using CiberGestion.Dominio.Contexto;
using CiberGestion.Dominio.Entidade;
using CiberGestion.Dominio.Interface;
using CiberGestion.Dominio.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace CiberGestion.Dominio.Repositorio
{
    public class RepositorioLogin : ILogin
    {
        private readonly EFDbContexto _db = new EFDbContexto();

        public UsuarioLogin Acessar(string login, string senha, string ip)
        {
            var senhaCrypt = Crypto.Encrypt(senha, Crypto.Key256, 256);
            var usuario = _db.Database.SqlQuery<UsuarioLogin>("SP_AdministradorLogin @dsLogin , @dsSenha , @dsIP",
                                                         new SqlParameter("dsLogin", login)
                                                        , new SqlParameter("dsSenha", senhaCrypt)
                                                        , new SqlParameter("dsIP", ip)).FirstOrDefault();

            if (usuario != null && usuario.idAdministrador > 0)
            {
                FormsAuthentication.SetAuthCookie("loginUsuarioAdmin", false);
                Geral.criaCookie(new UsuarioLogin
                {

                    idAdministrador = usuario.idAdministrador
                    ,
                    dsEmail = usuario.dsEmail
                    ,
                    dsLogin = usuario.dsLogin
                    ,
                    dsNome = usuario.dsNome , idTipo = usuario.idTipo  , dsTipo = usuario.dsTipo,dsSenha = usuario.dsSenha
                });

                Geral.CriaCookiePermissao(usuario.dsTipo);
            }

            return usuario;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
