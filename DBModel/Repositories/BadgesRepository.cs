using Common.Enumerations;
using Common.Model;
using DBModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Repositories
{
    public class BadgesRepository : IBadgesRepository
    {

        private EDMContainer db = new EDMContainer();

        public List<BadgesModel> GetBadges(int profileId)
        {
            var badges = (from badge in db.Badges
                          join response in db.SystemQuestions
                          on badge.badgeId equals response.Badge_badgeId
                          where (response.Profile_profileId == profileId
                          && response.userLevel == UserSkillLevel.Intermediate.ToString())
                          select new BadgesModel()
                          {
                              BadgeId = badge.badgeId,
                              BadgeName = badge.badgeTitle,
                              Description = badge.description
                          }).ToList();
            return badges;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
