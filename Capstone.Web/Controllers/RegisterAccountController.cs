using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBModel;
using Interfaces;
using Repositories;

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
                repo.Add(account);
                return RedirectToAction("Index");
            }

            return View(account);
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
