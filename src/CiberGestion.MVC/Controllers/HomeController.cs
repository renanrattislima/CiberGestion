using CiberGestion.Dominio.Entidade;
using CiberGestion.Dominio.Interface;
using CiberGestion.Dominio.Util;
using CiberGestion.MVC.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CiberGestion.MVC.Controllers
{
    [Authorize]
    [SessionCheckAttribute]
    public class HomeController : Controller
    {
       
        public HomeController()
        {
          

        }

   
        public ActionResult Index()
        {
           
            return View();
        }

    }
}
