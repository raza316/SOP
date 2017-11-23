using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOP.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                
                return View();
            }
            else
            {
                Response.Redirect("~/Account/Login", false);
                return RedirectToAction("Login", "Account");
            }

        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

    }
}