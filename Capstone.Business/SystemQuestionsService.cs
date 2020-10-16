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
            foreach (var skill in skills)
            {
                var sk = ProfileService.GetSkill(skill.SkillId);

                var reply = new SystemQuestions()
                {
                    userLevel = skill.SkillLevel,
                    Profile_profileId = user.ProfileId.Value,
                    Path_pathId = sk.Paths.FirstOrDefault().pathId,
                    skill = sk.skillName,
                    Badge_badgeId = sk.Badge_badgeId
                };

                Repository.AddSystemQuestion(reply);
            }
        }
    }
}
