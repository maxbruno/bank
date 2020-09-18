using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bank.Account.Domain.Models;

namespace Bank.Account.Domain.Interfaces
{
    public interface IAccountRepository : IDisposable
    {
        Task<IEnumerable<Models.Account>> GetAccounts();
        Task<Models.Account> GetAccountById(Guid accountId);
        Task<IEnumerable<Transaction>> GetTransactionsByAccountId(Guid accountId);
        void AddTransaction(Transaction transaction);
        void UpdateAccount(Models.Account account);
    }
}