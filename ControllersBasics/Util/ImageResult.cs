using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersBasics.Util
{
    public class ImageResult : ActionResult
    {
        string _path;

        public ImageResult(string path)
        {
            _path = path;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Write("<div>" +
                "<img src='" + _path + "'>" +
                "</div>");
        }
    }
}