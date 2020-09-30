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
    }
}
