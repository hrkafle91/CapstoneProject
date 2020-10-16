﻿using Common.Model;
using DBModel.Interfaces;
using DBModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Business
{
    public static class BadgesService
    {
        private static IBadgesRepository Repository = new BadgesRepository();

        public static List<BadgesModel> GetEarnedBadges(int profileId)
        {
            return Repository.GetEarnedBadges(profileId);
        }

        public static List<BadgesModel> GetRecommendedBadges(int profileId)
        {
            return Repository.GetRecommendedBadges(profileId);
        }
    }
}
