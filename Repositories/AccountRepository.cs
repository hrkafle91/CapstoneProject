using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DBModel;

namespace Repositories
{
    class AccountRepository : IAccountRepository
    {
        private EDMContainer db = new EDMContainer();

        public void Add(Account account)
        {
            db.Accounts.Add(account);
            db.SaveChanges();
        }

        public void Edit(Account account)
        {
            db.Entry(account).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int accountId)
        {
            Account account = db.Accounts.Find(accountId);
            db.Accounts.Remove(account);
        }

        public Account GetAccount(int accountId)
        {
            return db.Accounts.Find(accountId);
        }

        public List<Account> GetAllAccounts()
        {
            return db.Accounts.ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
