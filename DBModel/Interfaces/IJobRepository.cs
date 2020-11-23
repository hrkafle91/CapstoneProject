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

    }
}
