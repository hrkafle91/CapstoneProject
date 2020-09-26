﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using DBModel;
using WebScraper;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        Scraper sc = new Scraper();
        public ActionResult Index()
        {
            var user = Session["user"] as Account;
            if(user != null)
            {
                var badges = sc.ScrapeData("esmikle");
                ViewBag.Badges = badges;
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
