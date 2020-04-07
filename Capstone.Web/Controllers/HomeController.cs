using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using DBModel;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var user = Session["user"] as Account;
            if(user != null)
            {
                ViewData["username"] = user.userName;
                return View();
            } 
            else
            {
                return RedirectToAction("Index", "LoginAccount");
            }
            
        }

        public ActionResult SideMenu()
        {
            return PartialView("SideMenu");
        }
    }
}
