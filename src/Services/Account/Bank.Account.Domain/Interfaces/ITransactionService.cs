using System;
using System.Threading.Tasks;
using Bank.Account.Domain.Models;

namespace Bank.Account.Domain.Interfaces
{
    public interface ITransactionService : IDisposable
    {
        Task DebitAccount(Transaction transaction);
        Task DepositAccount(Transaction transaction);
        Task TransferAccount(Transaction transaction);
    }
}