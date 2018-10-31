using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CiberGestion.Dominio.Entidade;
using CiberGestion.Dominio.Interface;
using CiberGestion.Dominio.Util;

namespace CiberGestion.MVC.Controllers
{
    public class CadastroController : Controller
    {
        private readonly IAdministrador _repo;


        public class UsuarioDados
        {
            public int idUsuario { get; set; }
            public string dsNome { get; set; }
            public string dsTelefone { get; set; }
            public string dsTipoTelefone { get; set; }
            public DateTime dtCadastro { get; set; }
            public DateTime? dtAlteracao { get; set; }
            public bool btAtivo { get; set; }
        }

        public CadastroController(IAdministrador repo)
        {
            _repo = repo;
        }


        public ActionResult Index()
        {
            List<Usuario> users = new List<Usuario>();

            users = _repo.Listar(0);
            TempData["Usuarios"] = users;
            return View(users);

        }


        public ActionResult Editar(int idUsuario)
        {
            Usuario usuario = new Usuario();
            usuario = _repo.Listar(idUsuario)[0];
            TempData["Usuario"] = usuario;
            return View(usuario);

        }


        public ActionResult Novo()
        {
            Usuario loja = new Usuario();

            return View(loja);

        }


        [HttpPost]
        public JsonResult SalvarCadastro(string strDados)
        {
            UsuarioDados json = null;
            string Erro = string.Empty;
            RetornoPadrao RetornoPadrao = new RetornoPadrao();

            try
            {
                json = new JavaScriptSerializer().Deserialize<UsuarioDados>(strDados);

                if (json != null)
                {
                    Usuario user = new Usuario();
                    user.idUsuario = json.idUsuario;
                    user.dsNome = json.dsNome;
                    user.dsTelefone = json.dsTelefone;
                    user.dsTipoTelefone = json.dsTipoTelefone;

                    RetornoPadrao = _repo.CadastrarAlterar(user);
                    return Json(RetornoPadrao, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                Erro = ex.ToString();
                RetornoPadrao.Mensagem = Erro;
            }

            return Json(RetornoPadrao, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult AlterarCadastro(string strDados)
        {
            UsuarioDados json = null;
            string Erro = string.Empty;
            RetornoPadrao RetornoPadrao = new RetornoPadrao();

            try
            {
                json = new JavaScriptSerializer().Deserialize<UsuarioDados>(strDados);

                if (json != null)
                {
                    Usuario user = new Usuario();
                    user.idUsuario = json.idUsuario;
                    user.dsNome = json.dsNome;
                    user.dsTelefone = json.dsTelefone;
                    user.dsTipoTelefone = json.dsTipoTelefone;

                    RetornoPadrao = _repo.CadastrarAlterar(user);
                    return Json(RetornoPadrao, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                Erro = ex.ToString();
                RetornoPadrao.Mensagem = Erro;
            }

            return Json(RetornoPadrao, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ExcluiCadastro(string strDados)
        {
            UsuarioDados json = null;
            string Erro = string.Empty;
            RetornoPadrao RetornoPadrao = new RetornoPadrao();

            try
            {
                json = new JavaScriptSerializer().Deserialize<UsuarioDados>(strDados);

                if (json != null)
                {
                    Usuario user = new Usuario();
                    user.idUsuario = json.idUsuario;
                    user.dsNome = json.dsNome;
                    user.dsTelefone = json.dsTelefone;
                    user.dsTipoTelefone = json.dsTipoTelefone;

                    RetornoPadrao = _repo.Excluir(user);
                    return Json(RetornoPadrao, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                Erro = ex.ToString();
                RetornoPadrao.Mensagem = Erro;
            }

            return Json(RetornoPadrao, JsonRequestBehavior.AllowGet);
        }
    }
}
