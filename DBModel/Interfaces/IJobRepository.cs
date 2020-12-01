using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel;

namespace DBModel.Interfaces
{
    public interface IJobRepository : IDisposable
    {
        Job AddJob(Job job);
        Job GetJob(int jobId);
        Job UpdateJob(Job job);
        void DeleteJob(int jobId);
        List<Job> GetAllJobs();
        bool AddSkillsToJob(int jobId, List<int> skills);

    }
}
