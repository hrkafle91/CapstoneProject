using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBModel;
using System.Web.Mvc;
using Capstone.Web.ViewModels;
using DBModel.Repositories;
using Common.Model;
using Common.Enumerations;
using Capstone.Business;

namespace Capstone.Web.Controllers
{
    public class LoginAccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerifyAccount(string emailId, string password)
        {
            Account account = AccountService.GetAccountIfExists(emailId, password);
            if (account != null)
            {
                Session.RemoveAll();
                Session["user"] = UserService.SetUser(account);
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        public ActionResult VerifyAccountPost()
        {
            var user = (UserViewModel)Session["user"];
            if (user.UserType == UserTypeEnum.Applicant.ToString())
                return RedirectToAction("Index", "Home");
            else if (user.UserType == UserTypeEnum.Admin.ToString())
                return RedirectToAction("Index", "Admin");
            else
                return RedirectToAction("Index", "LoginAccount");
        }

        public ActionResult LogOut()
        {
            try
            {
                Session.RemoveAll();
                return Json(true);
            }
            catch
            {
                return Json(false);
            }
        }
    }
}