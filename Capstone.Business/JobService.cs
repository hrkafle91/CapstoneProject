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
        private static IJobRepository Repository = new JobRepository();

        public static Job AddJob(Job job)
        {
            return Repository.AddJob(job);
        }

    }
}
