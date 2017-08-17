using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ControllersBasics.Controllers
{
    public class MyController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            string ip = requestContext.HttpContext.Request.UserHostAddress;
            var respond = requestContext.HttpContext.Response;
            respond.Write("Your IP: " + ip);
        }
    }
}