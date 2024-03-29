﻿using Capstone.Business;
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
            var user = GetUser();
            SystemQuestionsService.SaveUserResponses(user, skills);
            return Json(skills);
        }

        public ActionResult SetCareerPath(string path)
        {
            var user = GetUser();
            SetUser(UserService.SetCareerPath(user, path));
            ProfileService.UpdateCareerPath(user, path);
            return Json(true);
        }

        public ActionResult Recommendations()
        {
            return View();
        }

        public ActionResult UpdateBadgeCompletionStatus(List<BadgeCompletionStatus> badges)
        {
            SystemQuestionsService.UpdateBadgeCompletionStatus(badges, GetUser());
            return Json(true);
        }
    }
}
