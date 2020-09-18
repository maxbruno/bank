using System.Collections.Generic;
using System.Threading.Tasks;
using WorkerServiceAccount.Models;

namespace WorkerServiceAccount.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAllAccounts();
        Task SendTransaction(Transaction transaction);
    }
}