using Common.Model;
using DBModel;
using DBModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public static Skill GetSkill(int skillId)
        {
            return GetAllSkills().Where(x => x.skillId == skillId).FirstOrDefault();
        }

        public static List<Skill> GetSkillsFByPath(string path)
        {
            var skills =  Repository.GetSkillsByPath(path);
            return skills;
        }

        public static Profile CreateApplicantProfile(Account account)
        {
            Profile profile = new Profile()
            {
                trailHeadUrl = "trailhead.me/id/" + account.userID,
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

        public static void UpdateCareerPath(UserViewModel user, string path)
        {
            var profile = GetProfile(user.ProfileId.Value);
            profile.careerPath = path;
            Repository.Edit(profile);
        }

        public static bool CheckIfProfileExists(int profileId)
        {
            var profile = GetProfile(profileId);
            var count = profile.SystemQuestions.Count;
            return count == 0 ? false : true;
        }
    }
}
