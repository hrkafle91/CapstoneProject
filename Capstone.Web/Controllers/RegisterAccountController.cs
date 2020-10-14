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
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using Capstone.Business;

namespace Capstone.Web.Controllers
{
    public class RegisterAccountController : Controller
    {
        public ActionResult Index()
        {
            return View(AccountService.GetAccounts());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = AccountService.GetAccount(Convert.ToInt32(id));
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userID,userName,password,firstName,lastName,emailID,userType")] Account account)
        {
            if (ModelState.IsValid)
            {
                int passcode = PasscodeHelper.GetPasscode();
                EmailHelper.SendPasscode(account, passcode);
                TempData["passcode"] = passcode;
                TempData["account"] = account;
                if (passcode != 0)
                {
                    return RedirectToAction("VerifyEmail");
                }            
            }
            return View();
        }

        static async Task SendEmail(Account account, int passcode)
        {
            var apiKey = System.Environment.GetEnvironmentVariable("SENDGRID_WEB_API");
            var client = new SendGridClient(apiKey);

            var msg = new SendGridMessage();

            msg.SetFrom(new EmailAddress("noreply.nrnacanada@gmail.com", "TRIOS Capstone"));

            var recipients = new List<EmailAddress>
            {
                new EmailAddress(account.emailID, account.firstName + ' ' + account.lastName),
            };

            msg.AddTos(recipients);

            msg.SetSubject("Passcode for Registration");

            string content = $"<p>Hello {account.firstName } {account.lastName},</p>" +
                $"<br><p>Please use {passcode} as a passcode for registration.</p>" +
                $"<br><p>Thank you...</p>" +
                $"<br><h3>TRIOS Capstone Team</h3>";

            //msg.AddContent(MimeType.Text, "Hello World plain text!");
            msg.AddContent(MimeType.Html, content);

            var response = await client.SendEmailAsync(msg);
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
            Account account = AccountService.GetAccount(Convert.ToInt32(id));
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
                AccountService.EditAccount(account);
                Session.Clear();
                Session["user"] = UserService.SetUser(account, ProfileService.GetProfile(account.Profile.profileId));
                return RedirectToAction("Index", "Home");
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
            Account account = AccountService.GetAccount(Convert.ToInt32(id)); 
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
            AccountService.DeleteAccount(id);
            return RedirectToAction("Index", "LoginAccount");
        }

        [HttpPost]
        public ActionResult ConfirmEmailValidation(int? enteredCode)
        {
            int generatedCode = (int)TempData["passcode"];
            Account account = (Account)TempData["account"];

            LogService.Write("Logged");
            if (enteredCode.Value == generatedCode)
            {
                LogService.Write("Entered code is correct");
                var profile = ProfileService.CreateProfile();

                LogService.Write("Profile created");
                account.profileId = 1;
                AccountService.AddAccount(account);

                LogService.Write("Account created");

                Session["user"] = UserService.SetUser(account, profile);
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        public ActionResult ResendPasscode()
        {
            Account account = (Account)TempData["account"];
            int passcode = PasscodeHelper.GetPasscode();
            SendEmail(account, passcode).Wait();
            TempData["passcode"] = passcode;
            return RedirectToAction("VerifyEmail");
        }

    }
}
