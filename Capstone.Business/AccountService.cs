using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Model;
using DBModel;
using DBModel.Repositories;
using DBModel.Interfaces;

namespace Capstone.Business
{
    
    public static class AccountService
    {
        private static IAccountRepository Repository = new AccountRepository();

        public static Applicant AddApplicant()
        {
            return null;
        }
    }
}
