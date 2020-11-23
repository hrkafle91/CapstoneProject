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


        public void Dispose()
        {
            db.Dispose();
        }
    }
}
