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
            db.Entry(job).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return job;

        }

        public Job GetJob(int? jobId)
        {
            return db.Jobs.Where(x => x.Id == jobId).FirstOrDefault();
        }

        public void DeleteJob(int jobId)
        {
            var job = db.Jobs.Find(jobId);
            job.Skills.Clear();
            db.Jobs.Remove(job);
            db.SaveChanges();
        }

        public List<Job> GetAllJobs()
        {
            return db.Jobs.ToList();
        }

        public Skill GetSkill(int id)
        {
            return db.Skills.Where(x => x.skillId == id).FirstOrDefault();
        }

        public List<Badge> GetBadgesBySkills(List<Skill> skills)
        {
            List<Badge> badges = new List<Badge>();

            foreach(var skill in skills)
            {
                var sk = badges.Find(x => x.badgeId == skill.Badge.badgeId);
                if (sk == null)
                {
                    Badge bd = new Badge();
                    bd.badgeId = skill.Badge.badgeId;
                    bd.badgeTitle = skill.Badge.badgeTitle;
                    bd.description = skill.Badge.description;
                    bd.link = skill.Badge.link;
                    badges.Add(bd);
                }
            }

            return badges.Distinct().ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }

       
    }

}
