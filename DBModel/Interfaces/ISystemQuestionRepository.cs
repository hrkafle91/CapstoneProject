﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Interfaces
{
    public interface ISystemQuestionRepository : IDisposable
    {
        void CreateSystemQuestion(SystemQuestions question);
        void Delete(int sqId);
        void Edit(SystemQuestions question);
        List<SystemQuestions> GetAllSystemQuestions();
        List<SystemQuestions> GetSystemQuestionsByProfileId(int profileId);
        SystemQuestions GetSystemQuestion(int sqId);
    }
}