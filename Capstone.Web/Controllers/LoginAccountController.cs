using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBModel;
using System.Web.Mvc;
using Capstone.Web.ViewModels;
using DBModel.Repositories;
using Common.Model;
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
            Profile profile = ProfileService.GetProfile(account.Profile.profileId);
            if (account != null)
            {
                Session["user"] = UserService.SetUser(account, profile);
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
    }
}