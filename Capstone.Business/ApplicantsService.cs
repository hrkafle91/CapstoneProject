using Common.Enumerations;
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
    public class ApplicantsService
    {
        private static AccountRepository Repository = new AccountRepository();

        public static List<UserViewModel> GetAllApplicants()
        {
            var accounts = Repository.GetAllAccounts();
            List<UserViewModel> applicants = new List<UserViewModel>();

            foreach(Account acc in accounts)
            {
                if(acc.userType.Equals(UserTypeEnum.Applicant.ToString()))
                {
                    UserViewModel applicant = UserService.SetUser(acc);
                    applicant.CompletionPercentage = BadgesService.GetCompletionPercentage(acc.userID);
                    applicants.Add(applicant);
                }
            }

            return applicants;
        }

        public static UserViewModel GetApplicant(int id)
        {
            var account = Repository.GetAccount(id);

            return UserService.SetUser(account);
        }
    }
}
