using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace SignalR.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            if(Session["UserName"] == null)
            {
                Response.Redirect("/Login/Index",true);
            }
        }
    
    }
}