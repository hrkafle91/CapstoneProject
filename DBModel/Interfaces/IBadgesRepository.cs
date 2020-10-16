using System;
using Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Model;

namespace DBModel.Interfaces
{
    public interface IBadgesRepository : IDisposable
    {
        List<BadgesModel> GetBadges(int profileId);
    }
}
