using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBModel;
using System.Web.Mvc;
using Capstone.Web.ViewModels;
using DBModel.Repositories;

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
            using (AccountRepository repo = new AccountRepository())
            {
                Account account = repo.GetAllAccounts().Where(x => x.emailID == emailId).FirstOrDefault();
                if ((account != null) && (account.password == password))
                {
                    Session["user"] = account;
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
        }
    }
}