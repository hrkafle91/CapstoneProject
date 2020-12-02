using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel;
using DBModel.Interfaces;
using DBModel.Repositories;

namespace Capstone.Business
{
    public static class JobService
    {
        private static JobRepository Repository = new JobRepository();

        public static Job AddJob(Job job)
        {
            return Repository.AddJob(job);
        }

        public static Job UpdateJob(Job job)
        {
            LogService.Write("Id: " + job.Id);
            LogService.Write(job.company);
            LogService.Write(job.jobDesc);
            return Repository.UpdateJob(job);
        }

        public static Job GetJob(int? jobId)
        {
            return Repository.GetJob(jobId);
        }

        public static void DeleteJob(int jobId)
        {
            Repository.DeleteJob(jobId);
        }

        public static List<Job> GetAllJobs()
        {
            return Repository.GetAllJobs();
        }

        public static Skill GetSkill(int id)
        {
            return Repository.GetSkill(id);
        }

        public static List<Badge> GetBadges(List<Skill> skills)
        {
            return Repository.GetBadgesBySkills(skills);
        }

    }
}
