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
            LogService.Write("Selected path is: " + path);
            var skills =  Repository.GetSkillsByPath(path);
            LogService.Write("Count of skills: " + skills.Count);
            skills.ForEach(x => LogService.Write(x.skillName));
            return skills;
        }

        public static Profile CreateProfile()
        {
            LogService.Write("I am here");
            Profile profile = new Profile()
            {
                trailHeadUrl = "n/a",
                careerPath = "n/a",
                careerPathCompletion = "0"
            };

            LogService.Write("about to add");

            var abc = Repository.CreateProfile(profile);
            LogService.Write("Profile added; ID: " + abc.profileId);
            return abc;
        }

        public static Profile GetProfile(int profileId)
        {
            return Repository.GetProfile(profileId);
        }
    }
}
