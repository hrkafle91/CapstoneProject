using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBModel;
using DBModel.Repositories;
using Capstone.Web.Helpers;

namespace Capstone.Web.Controllers
{
    public class RegisterAccountController : Controller
    {

        private AccountRepository repo = new AccountRepository();

        // GET: RegisterAccount
        public ActionResult Index()
        {
            return View(repo.GetAllAccounts());
        }

        // GET: RegisterAccount/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = repo.GetAccount(Convert.ToInt32(id));
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: RegisterAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegisterAccount/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userID,userName,password,firstName,lastName,emailID,userType")] Account account)
        {
            if (ModelState.IsValid)
            {
                int passcode = Helpers.EmailHelper.SendPasscode(account);
                TempData["passcode"] = passcode;
                TempData["account"] = account;
                if (passcode != 0)
                {
                    return RedirectToAction("VerifyEmail");
                }            
            }
            return View();
        }

        // GET: RegisterAccount/Create
        public ActionResult VerifyEmail()
        {
            return View();
        }

        // GET: RegisterAccount/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = repo.GetAccount(Convert.ToInt32(id));
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: RegisterAccount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userID,userName,password,firstName,lastName,emailID,userType")] Account account)
        {
            if (ModelState.IsValid)
            {
                repo.Edit(account);
                return RedirectToAction("Index");
            }
            return View(account);
        }

        // GET: RegisterAccount/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = repo.GetAccount(Convert.ToInt32(id)); 
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: RegisterAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ConfirmEmailValidation(int? enteredCode)
        {
            int generatedCode = (int)TempData["passcode"];
            Account account = (Account)TempData["account"];
            if (enteredCode.Value == generatedCode)
            {
                repo.Add(account);
                return Json(true);
            }
            else
                return Json(false);
        }

        public ActionResult ResendPasscode()
        {
            LogHelper.WriteLog("line 143");
            Account account = (Account)TempData["account"];
            int passcode = Helpers.EmailHelper.SendPasscode(account);
            TempData["passcode"] = passcode;
            return RedirectToAction("VerifyEmail");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
