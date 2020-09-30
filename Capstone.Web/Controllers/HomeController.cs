using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Common.Model;
using DBModel;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var user = Session["user"] as UserViewModel;
            if(user != null)
            {
                return View(user);
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

        public ActionResult Edit(int? id)
        {
            return RedirectToAction("Edit/"+id, "RegisterAccount");
        }

        public ActionResult Delete(int? id)
        {
            return RedirectToAction("Delete/" + id, "RegisterAccount");
        }
    }
}
