using Capstone.Business;
using Common.Model;
using Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var applicants = ApplicantsService.GetAllApplicants();

            return View(applicants);
        }

        public PartialViewResult SearchApplicants(string searchText, char val)
        {
            List<UserViewModel> model = ApplicantsService.GetAllApplicants();
            searchText = searchText.ToLower();
            List<UserViewModel> result = null;

            switch (val)
            {
                case '1':
                    result = model.Where(x => x.FirstName.ToLower().Contains(searchText)).ToList();
                    break;
                case '2':
                    result = model.Where(x => x.Lastname.ToLower().Contains(searchText)).ToList();
                    break;
                case '3':
                    result = model.Where(x => x.CompletionPercentage.ToString().Contains(searchText)).ToList();
                    break;
                case '4':
                    result = model.Where(x => x.EmailId.ToLower().Contains(searchText)).ToList();
                    break;
            }

            return PartialView("_TableView", result);
        }

        public PartialViewResult FilterApplicantsByCareerPathThenSort(char filterVal, char sortVal)
        {
            List<UserViewModel> model = ApplicantsService.GetAllApplicants();
            List<UserViewModel> result = null;

            LogService.Write("FilterVal: " + filterVal);
            if (filterVal.Equals('1'))
            {
                result = model.Where(x => x.CareerPath.Equals(CareerPath.Administrator.ToString()) && (x.CompletionPercentage > 0.0) ).ToList();
                LogService.Write("Admin:" + result.Count.ToString());
            }
            else if (filterVal.Equals('2'))
            {
                result = model.Where(x => x.CareerPath.Equals(CareerPath.Developer.ToString()) && x.CompletionPercentage > 0.0).ToList();
            }
            else
            {
                result = model.Where(x => x.CompletionPercentage > 0.0).ToList();
                LogService.Write("Default:" + result.Count.ToString());
            }

            switch (sortVal)
            {
                case '1':
                    result = result.OrderBy(x => x.FirstName).ToList();
                    break;
                case '2':
                    result = result.OrderBy(x => x.Lastname).ToList();
                    break;
                case '3':
                    result = result.OrderBy(x => x.CareerPath).ToList();
                    break;
                case '5':
                    result = result.OrderBy(x => x.EmailId).ToList();
                    break;
                default:
                    result = result.OrderByDescending(x => x.CompletionPercentage).ToList();
                    break;
            }


            return PartialView("_TableView", result);
        }

        public ActionResult SideMenu()
        {
            return PartialView("SideMenu");
        }
    }
}