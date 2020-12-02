using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel;
using DBModel.Interfaces;
using DBModel.Repositories;

namespace Capstone.Business
{
    public static class AccountService
    {
        private static IAccountRepository Repository = new AccountRepository();

        public static Account AddAccount(Account account)
        {
            return Repository.AddAccount(account);
        }

        public static Account GetAccount(int accountId)
        {
            return Repository.GetAccount(accountId);
        }

        public static Account EditAccount(Account account)
        {
            return Repository.EditAccount(account);
        }

        public static void DeleteAccount(int accountId)
        {
            Repository.DeleteAccount(accountId);
        }

        public static List<Account> GetAccounts()
        {
            return Repository.GetAllAccounts();
        }

        public static Account GetAccountIfExists(string emailId, string password)
        {
            Account account = GetAccounts().Where(a => a.emailID == emailId).FirstOrDefault();
            if(account != null && account.password == password)
            {
                return account;
            }
            else
            {
                return null;
            }
        }

        public static List<string> GetAllExistingEmails()
        {
            return GetAccounts().Select(x => x.emailID).ToList();
        }
    }
}
