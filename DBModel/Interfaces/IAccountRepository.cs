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
        void AddAccount(Account account);
        void DeleteAccount(int accountId);
        void EditAccount(Account account);
        List<Account> GetAllAccounts();
        Account GetAccount(int accountId);
    }
}
