using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel;

namespace DBModel.Interfaces
{
    public interface IAccountRepository : IDisposable
    {
        void Add(Account account);
        void Delete(int accountId);
        void Edit(Account account);
        List<Account> GetAllAccounts();
        Account GetAccount(int accountId);
    }
}
