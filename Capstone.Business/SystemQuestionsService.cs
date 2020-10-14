using Common.Model;
using DBModel;
using DBModel.Repositories;
using DBModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Business
{
    public static class SystemQuestionsService
    {
        private static ISystemQuestionRepository Repository = new SystemQuestionRepository();

        public static void SaveUserResponses(UserViewModel user, List<SkillsLevel> skills)
        {
            foreach(var skill in skills)
            {
                var systemQuestion = new SystemQuestions()
                {
                    skill_id = skill.SkillId,
                    userLevel = skill.SkillLevel,
                    Profile_profileId = user.ProfileId.Value,
                    Path_pathId = user.PathId.Value,
                    Badge_badgeId = skill.BadgeId.Value
                };
                Repository.CreateSystemQuestion(systemQuestion);
            }
        }
    
    }
}
