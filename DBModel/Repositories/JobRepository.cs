using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel.Interfaces;
using DBModel;

namespace DBModel.Repositories
{
    public class JobRepository : IJobRepository
    {
        private EDMContainer db = new EDMContainer();

        public Job AddJob(Job job)
        {
            job = db.Jobs.Add(job);
            db.SaveChanges();
            return job;
        }

        public Job UpdateJob(Job job)
        {
            Job nJob = GetJob(job.Id);
            if(nJob != null)
            {
                nJob.careerPath = job.careerPath;
                nJob.company = job.company;
                nJob.jobDesc = job.jobDesc;
                nJob.jobId = job.jobId;
                nJob.jobTitle = job.jobTitle;
                nJob.jobType = job.jobType;
            }
            else
            {
                AddJob(job);
            }

            db.SaveChanges();
            return nJob;
        }

        public Job GetJob(int jobId)
        {
            return db.Jobs.Where(x => x.Id == jobId).FirstOrDefault();
        }

        public void DeleteJob(int jobId)
        {
            var job = db.Jobs.Find(jobId);
            db.Jobs.Remove(job);
        }

        public List<Job> GetAllJobs()
        {
            return db.Jobs.ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public bool AddSkillsToJob(int jobId, List<int> skillIds)
        {
            try
            {
                var job = GetJob(jobId);
                var skills = (new ProfileRepository()).GetAllSkills();
                skillIds.ForEach(s => job.Skills.Add(skills.FirstOrDefault(x => x.skillId == s)));
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

    }
}
