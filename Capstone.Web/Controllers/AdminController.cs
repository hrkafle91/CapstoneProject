using Capstone.Business;
using Common.Model;
using Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBModel;
using System.Net;

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

        public ActionResult CreateJob()
        {
            JobSkillsVM jobSkillVM = new JobSkillsVM();

            List<Skill> skills = ProfileService.GetAllSkills();

            foreach (var skill in skills)
            {
                ReqSkill reqSkill = new ReqSkill();
                reqSkill.SkillId = skill.skillId;
                reqSkill.SkillName = skill.skillName;
                reqSkill.isChecked = false;

                jobSkillVM.RequiredSkills.Add(reqSkill);
            }

            return View(jobSkillVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateJob(JobSkillsVM jobSkillVM)
        {
            if (ModelState.IsValid)
            {
                Job jb = new Job();
                jb.careerPath = ((CareerPath)(Int32.Parse(jobSkillVM.CareerPath))).ToString();
                jb.company = jobSkillVM.Company;
                jb.jobDesc = jobSkillVM.JobDesc;
                jb.jobId = jobSkillVM.JobRef;
                jb.jobTitle = jobSkillVM.JobTitle;
                jb.jobType = jobSkillVM.JobType;

                foreach (var skill in jobSkillVM.RequiredSkills)
                {
                    if (skill.isChecked)
                    {
                        Skill sk = JobService.GetSkill(skill.SkillId);
                        jb.Skills.Add(sk);
                    }
                }
                JobService.AddJob(jb);
                return RedirectToAction("Index", "Admin");
            }
            else
                return View(jobSkillVM);
            
        }

        public ActionResult UpdateJob(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Job job = JobService.GetJob(id); 

            if(job == null)
            {
                return HttpNotFound();
            }

            JobSkillsVM jobSkillsVM = new JobSkillsVM(job.jobTitle, job.jobDesc, job.jobId, (Enum.Parse(typeof(CareerPath),job.careerPath)).ToString(), job.company, job.jobType, job.Id);
            List<Skill> skills = ProfileService.GetAllSkills();
            
            foreach(var skill in skills)
            {
                ReqSkill reqSkill = new ReqSkill();
                reqSkill.SkillId = skill.skillId;
                reqSkill.SkillName = skill.skillName;

                var sk = job.Skills.ToList().Find(x => x.skillId == skill.skillId);
                if (sk == null)
                {
                    reqSkill.isChecked = false;
                }
                else
                    reqSkill.isChecked = true;

                jobSkillsVM.RequiredSkills.Add(reqSkill);
            }
            return View(jobSkillsVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateJob(JobSkillsVM jobSkillVM)
        {
            if (ModelState.IsValid)
            {
                Job jb = JobService.GetJob(jobSkillVM.Id);
                jb.careerPath = jobSkillVM.CareerPath;
                jb.company = jobSkillVM.Company;
                jb.jobDesc = jobSkillVM.JobDesc;
                jb.jobId = jobSkillVM.JobRef;
                jb.jobTitle = jobSkillVM.JobTitle;
                jb.jobType = jobSkillVM.JobType;

                jb.Skills.Clear();

                foreach (var skill in jobSkillVM.RequiredSkills)
                {
                    if (skill.isChecked)
                    {
                        Skill sk = JobService.GetSkill(skill.SkillId);
                        jb.Skills.Add(sk);
                    }
                }

                JobService.UpdateJob(jb);
                return RedirectToAction("Index", "Admin");
            }
            else
                return View(jobSkillVM);
            
        }

        
        public ActionResult DeleteJob(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Job job = JobService.GetJob(id);

            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }
 
        [HttpPost, ActionName("DeleteJob")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id, jobTitle, company, careerPath, jobType, jobId, jobDesc")] Job job)
        {
            JobService.DeleteJob(job.Id);
            return RedirectToAction("Index", "Admin");
        }

        public PartialViewResult JobPostings() 
        {
            List<Job> model = JobService.GetAllJobs();

            return PartialView("_JobsGridView", model);
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

            if (filterVal.Equals('1'))
            {
                result = model.Where(x => x.CareerPath.Equals(CareerPath.Administrator.ToString()) && (x.CompletionPercentage > 0.0) ).ToList();
            }
            else if (filterVal.Equals('2'))
            {
                result = model.Where(x => x.CareerPath.Equals(CareerPath.Developer.ToString()) && x.CompletionPercentage > 0.0).ToList();
            }
            else
            {
                result = model.Where(x => x.CompletionPercentage > 0.0).ToList();
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

        public ActionResult ApplicantDetails(int id)
        {
            UserViewModel applicant = ApplicantsService.GetApplicant(id);

            return View("ApplicantDetails", applicant);
        }

        public ActionResult GetSkillsByPath(int? path)
        {
            return Json((from skill in ProfileService.GetSkillsByPath(((CareerPath)path).ToString())
                        select new
                        {
                            SkillId = skill.skillId,
                            Skill = skill.skillName
                        }).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}