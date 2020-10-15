using DBModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Repositories
{
    public class SystemQuestionRepository : ISystemQuestionRepository
    {
        private EDMContainer db = new EDMContainer();
        public void AddSystemQuestion(SystemQuestions question)
        {
            db.SystemQuestions.Add(question);
            db.SaveChanges();
        }

        public void AddSystemQuestions(List<SystemQuestions> questions)
        {
            db.SystemQuestions.AddRange(questions);
            db.SaveChanges();
        }

        public void Delete(int sqId)
        {
            SystemQuestions question = db.SystemQuestions.Find(sqId);
            db.SystemQuestions.Remove(question);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public void Edit(SystemQuestions question)
        {
            db.Entry(question).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public List<SystemQuestions> GetAllSystemQuestions()
        {
            return db.SystemQuestions.ToList();
        }

        public List<SystemQuestions> GetSystemQuestionsByProfileId(int profileId)
        {
            return db.SystemQuestions.Where(x => x.Profile_profileId == profileId).ToList();
        }

        public SystemQuestions GetSystemQuestion(int sqId)
        {
            return db.SystemQuestions.Find(sqId);
        }
    }
}
