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

        public static void CreateProfile(UserViewModel user)
        {
            Profile profile = new Profile()
            {
                careerPath = user.CareerPath,
                careerPathCompletion = "0%"
            };
            Repository.CreateProfile(profile);
        }
    }
}
