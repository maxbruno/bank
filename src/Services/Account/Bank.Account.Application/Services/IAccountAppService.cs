using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bank.Account.Application.ViewModels;

namespace Bank.Account.Application.Services
{
    public interface IAccountAppService : IDisposable
    {
        Task<IEnumerable<AccountViewModel>> GetAll();
        Task<IEnumerable<TransactionViewModel>> GetByAccountId(Guid accountId);
        Task<TransactionViewModel> Transaction(TransactionInputViewModel transactionVM);        
    }
}