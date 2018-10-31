using CiberGestion.Dominio.Entidade;
using CiberGestion.Dominio.Interface;
using CiberGestion.Dominio.Util;
using CiberGestion.MVC.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CiberGestion.MVC.Controllers
{

    public class LoginController : Controller
    {

        private readonly ILogin _login;

        public LoginController(ILogin login)
        {
            _login = login;
        }

        public ActionResult Index()
        {
            return View(new Login());
        }

        public ActionResult Acessar(Login dados)
        {
            var isValida = dados.ValidaCampos();
            var ip = System.Web.HttpContext.Current.Request.UserHostAddress;

            if (!string.IsNullOrEmpty(isValida))
            {
                return View("Index", dados);
            }

            var usuario = _login.Acessar(dados.LoginUser, dados.Senha, ip);

            if (usuario != null && usuario.idAdministrador > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                dados.Mensagem = "Login ou senha inválidos.";
            }

            return View("Index", dados);
        }

        public ActionResult Sair()
        {

            HttpCookie c = Request.Cookies["UsuarioAdmin"];

            Geral.RemoveCookie("UsuarioAdmin");
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
