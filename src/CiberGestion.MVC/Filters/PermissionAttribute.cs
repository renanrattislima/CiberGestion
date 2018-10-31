using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace Fullbar.MaisTop.Web.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class PermissionAttribute : FilterAttribute, IAuthorizationFilter
    {
        public string Roles { get; set; }
        public PermissionAttribute(String Roles)
        {
            this.Roles = Roles;
        }
        public void OnAuthorization(AuthorizationContext filterContext)
        {

            if (filterContext.HttpContext.Request.Cookies.Get("PermissaoAdminCookie") != null)
            {
                var httpCookie = filterContext.HttpContext.Request.Cookies.Get("PermissaoAdminCookie");

                if (httpCookie != null)
                {
                    var itemSession = HttpContext.Current.Server.UrlDecode(httpCookie.Values.ToString().Split('=')[1]);

                    if (itemSession != null)
                    {
                        var ItemRoles = Roles.Split(',');
                        var i = 0;
                        var j = 0;
                        var f = false;
                        while (i < ItemRoles.Count() && !f)
                        {
                            j = 0;

                            if (ItemRoles[i] == itemSession)
                            {
                                f = true;
                            }

                            i++;
                        }
                        if (f == false)
                        {
                            FormsAuthentication.SignOut();
                            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Login", Action = "Sair" }));
                        }
                    }
                }
            }

            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Login", Action = "Sair" }));
            }
        }
    }
}