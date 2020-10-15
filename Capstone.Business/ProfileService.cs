using Common.Model;
using DBModel;
using DBModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Business
{
    public static class ProfileService
    {
        private static ProfileRepository Repository = new ProfileRepository();

        public static List<Skill> GetAllSkills()
        {
            return Repository.GetAllSkills();
        }

        public static List<Skill> GetSkillsFByPath(string path)
        {
            var skills =  Repository.GetSkillsByPath(path);
            skills.ForEach(x => LogService.Write(x.skillName));
            return skills;
        }

        public static Profile CreateApplicantProfile(Account account)
        {
            Profile profile = new Profile()
            {
                trailHeadUrl = "salesforce.com/" + account.userName,
                careerPath = "n/a",
                careerPathCompletion = "0",
                Account = account
            };
            return Repository.CreateProfile(profile);
        }

        public static Profile GetProfile(int profileId)
        {
            return Repository.GetProfile(profileId);
        }
    }
}
