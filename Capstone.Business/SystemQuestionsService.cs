using DBModel;
using DBModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Business
{
    public static class SystemQuestionsService
    {
        private static SystemQuestionRepository repo = new SystemQuestionRepository();

        public static void AddQuestion(SystemQuestions question)
        {
           repo.CreateSystemQuestion(question);
        }

        public static void EditQuestion(SystemQuestions question)
        {
            repo.Edit(question);
        }

        public static List<SystemQuestions> GetSystemQuestionsByProfile (int profileId)
        {
            return repo.GetSystemQuestionsByProfileId(profileId);
        }

        public static void DeleteQuestion(int sqId)
        {
            repo.Delete(sqId);
        }

    }
}
