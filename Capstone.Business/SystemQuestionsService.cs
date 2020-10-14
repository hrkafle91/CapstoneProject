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

        public static void SaveUserResponses(List<SkillsLevel> skills)
        {
            foreach(var skill in skills)
            {
                var systemQuestion = new SystemQuestions()
                {
                    skill_id = skill.SkillId,
                    userLevel = skill.SkillLevel
                };
                Repository.CreateSystemQuestion(systemQuestion);
            }
        }
    
    }
}
