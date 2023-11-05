using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetFlixPrac.Controllers
{
    public class OTTController : Controller
    {
       public string GetCurresntUserName()
        {
            return "Admin";
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}