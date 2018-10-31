using CiberGestion.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;


namespace CiberGestion.Dominio.Util
{
    public static class Geral
    {
        static Regex RegExEmail = new Regex(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,17})$");

        public static bool isEmail(string sEmail)
        {
            return RegExEmail.Match(sEmail).Success;
        }

        public static bool isCPF(string CPF)
        {
            if (CPF.Trim().Length == 0)
                return false;

            int[] mt1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mt2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string TempCPF;
            string Digito;
            int soma;
            int resto;

            CPF = CPF.Trim();
            CPF = CPF.Replace(".", "").Replace("-", "");

            if (CPF.Length != 11)
                return false;

            if (CPF == "11111111111" || CPF == "22222222222" || CPF == "33333333333" || CPF == "44444444444" || CPF == "55555555555" || CPF == "66666666666" || CPF == "77777777777" || CPF == "88888888888" || CPF == "99999999999")
                return false;

            TempCPF = CPF.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(TempCPF[i].ToString()) * mt1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            Digito = resto.ToString();
            TempCPF = TempCPF + Digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(TempCPF[i].ToString()) * mt2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            Digito = Digito + resto.ToString();

            return CPF.EndsWith(Digito);
        }

        public static bool isRG(string par_rg)
        {
            par_rg = par_rg.ToUpper().Replace("-", "").Replace(".", "");

            if (par_rg.Trim().Length < 9)
                return false;

            int rg = Convert.ToInt32(par_rg.Substring(0, 8)), d1 = 0, d2 = 0, d3 = 0, d4 = 0, d5 = 0, d6 = 0, d7 = 0, d8 = 0;
            int md1 = 0, md2 = 0, md3 = 0, md4 = 0, md5 = 0, md6 = 0, md7 = 0, md8 = 0;
            int m1 = 0, m2 = 0, m3 = 0, m4 = 0, m5 = 0, m6 = 0, m7 = 0, m8 = 0, mt = 0, dv;

            d1 = rg / 10000000;
            m1 = d1 * 9;
            md1 = rg % 10000000;
            d2 = md1 / 1000000;
            m2 = d2 * 8;
            md2 = md1 % 1000000;
            d3 = md2 / 100000;
            m3 = d3 * 7;
            md3 = md2 % 100000;
            d4 = md3 / 10000;
            m4 = d4 * 6;
            md4 = md3 % 10000;
            d5 = md4 / 1000;
            m5 = d5 * 5;
            md5 = md4 % 1000;
            d6 = md5 / 100;
            m6 = d6 * 4;
            md6 = md5 % 100;
            d7 = md6 / 10;
            m7 = d7 * 3;
            md7 = md6 % 10;
            d8 = md7 / 1;
            m8 = d8 * 2;
            md8 = md7 % 1;
            mt = m1 + m2 + m3 + m4 + m5 + m6 + m7 + m8;
            dv = mt % 11;
            string Digito;
            if (dv == 10)
                Digito = "X";
            else
                Digito = dv.ToString();

            return par_rg.EndsWith(Digito);
        }

        // public static void criaCookie(Usuario valor)
        // {

        //     System.Web.HttpCookie cookie = new System.Web.HttpCookie("UsuarioLogado");


        //     cookie["IdUsuario"] = valor.Idusuario.ToString();
        //     cookie["Nome"] = valor.Nome;
        //     cookie["Email"] = valor.Email;
        //     cookie["CPF"] = valor.CPF;

        //     DateTime dtNow = DateTime.Now;
        //     TimeSpan tsMinute = new TimeSpan(0, 0, 20, 0);
        //     cookie.Expires = dtNow + tsMinute;

        //     //Adiciona o cookie
        //     System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
        // }

        // public static Usuario recuperaCookie()
        // {
        //     System.Web.HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies["UsuarioLogado"];

        //     if (cookie == null)
        //     {
        //         return new Usuario();
        //     }
        //     else
        //     {
        //         var usuario = new Usuario {

        //             Idusuario = Convert.ToInt32(cookie.Value.Split('&')[0].Split('=')[1]),
        //             Nome = cookie.Value.Split('&')[1].Split('=')[1],
        //             Email = cookie.Value.Split('&')[2].Split('=')[1],
        //             CPF = cookie.Value.Split('&')[3].Split('=')[1],
        //         };

        //         return usuario;
        //     }
        //}

        // public static void removerCookie()
        // {

        //     if (System.Web.HttpContext.Current.Request.Cookies["UsuarioLogado"] != null)
        //     {
        //         System.Web.HttpContext.Current.Response.Cookies["UsuarioLogado"].Expires = DateTime.Now.AddYears(-30);
        //         System.Web.HttpContext.Current.Response.Cookies.Remove("UsuarioLogado");
        //     }

        // }  

        public static void criaCookie(UsuarioLogin valor)
        {

            System.Web.HttpCookie cookie = new System.Web.HttpCookie("UsuarioAdmin");

            var nome = HttpContext.Current.Server.UrlEncode(valor.dsNome);

            cookie["idAdministrador"] = valor.idAdministrador.ToString();
            cookie["Nome"] = nome;
            cookie["Email"] = valor.dsEmail;
            cookie["Login"] = valor.dsLogin;
            cookie["idTipo"] = valor.idTipo.ToString(CultureInfo.InvariantCulture);
            cookie["dsTipo"] = valor.dsTipo;
            cookie["dsSenha"] = HttpContext.Current.Server.UrlEncode(valor.dsSenha);

            DateTime dtNow = DateTime.Now;
            TimeSpan tsMinute = new TimeSpan(0, 0, 60, 0);
            cookie.Expires = dtNow + tsMinute;

            //Adiciona o cookie
            System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static UsuarioLogin recuperaCookie()
        {
            try
            {
                System.Web.HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies["UsuarioAdmin"];

                if (cookie == null)
                {
                    return new UsuarioLogin();
                }
                else
                {
                    var usuario = new UsuarioLogin
                    {

                        idAdministrador = Convert.ToInt32(cookie.Value.Split('&')[0].Split('=')[1]),
                        dsNome = HttpContext.Current.Server.UrlDecode(cookie.Value.Split('&')[1].Split('=')[1]),
                        dsEmail = cookie.Value.Split('&')[2].Split('=')[1],
                        dsLogin = cookie.Value.Split('&')[3].Split('=')[1],
                        idTipo = Convert.ToInt16(cookie.Value.Split('&')[4].Split('=')[1]),
                        dsTipo = cookie.Value.Split('&')[5].Split('=')[1],
                        dsSenha = HttpContext.Current.Server.UrlDecode(cookie.Value.Split('&')[6].Split('=')[1])

                    };

                    return usuario;
                }
            }
            catch
            {


            }

            return new UsuarioLogin();

        }

        public static void RemoveCookie(string cookieName)
        {
            if (HttpContext.Current.Response.Cookies[cookieName] != null)
            {
                HttpContext.Current.Response.Cookies[cookieName].Value = null;
                HttpContext.Current.Response.Cookies[cookieName].Expires = DateTime.Now.AddMonths(-1);
            }
        }

        public static void CriaCookiePermissao(string perfil)
        {

            var cookie = new HttpCookie("PermissaoAdminCookie");

            var perfil_ = HttpContext.Current.Server.UrlEncode(perfil.Replace(" ", "").Replace("/", "").Replace("ÇÃO", "CAO"));

            cookie["Perfil"] = perfil_;

            var dtNow = DateTime.Now;
            var tsMinute = new TimeSpan(0, 0, 20, 0);
            cookie.Expires = dtNow + tsMinute;

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static string RecuperaCookiePermissao()
        {
            try
            {
                var cookie = HttpContext.Current.Request.Cookies["PermissaoAdminCookie"];
                var perfil = string.Empty;

                if (cookie == null)
                {
                    return perfil;
                }
                else
                {
                    perfil = HttpContext.Current.Server.UrlDecode(cookie.Value);

                    return perfil;
                }
            }
            catch
            {
            }

            return string.Empty;

        }
    }
}
