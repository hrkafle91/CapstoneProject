using Capstone.Business;
using Common.Model;
using DBModel;
using DBModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class ProfileController : Controller
    {
        private ProfileRepository repo = new ProfileRepository();

        public UserViewModel GetUser()
        {
            return (UserViewModel) Session["user"];
        }

        public void SetUser(UserViewModel user)
        {
            Session["user"] = user;
        }
        public ActionResult CreateProfile()
        {
            return View();
        }

        public ActionResult QuestionsView()
        {
            var user = GetUser();
            return View(user);
        }

        public ActionResult GetSkillsQuestion()
        {
            var skills = ProfileService.GetAllSkills();
            return Json(skills);
        }

        public ActionResult PostSkillLevels(List<SkillsLevel> skills)
        {
            ProfileService.CreateProfile(GetUser());
            return Json(skills);
        }

        public ActionResult SetCareerPath(string path)
        {
            var user = GetUser();
            SetUser(UserService.SetCareerPath(user, path));
            return Json(true);
        }

        public ActionResult Recommendations()
        {
            return View();
        }
    }
}
