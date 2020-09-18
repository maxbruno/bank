using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Account.Domain.Interfaces;
using Bank.Account.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank.Account.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountContext _context;

        public AccountRepository(AccountContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Models.Account>> GetAccounts()
        {
            return await _context.Account.AsNoTracking().ToListAsync();
        }

        public async Task<Domain.Models.Account> GetAccountById(Guid accountId)
        {
            return await _context.Account.FindAsync(accountId);
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByAccountId(Guid accountId)
        {
            return await _context.Transaction.AsNoTracking()
                .Where(x => x.AccountId == accountId)
                .OrderByDescending(x => x.CreateAt)
                .ToListAsync();
        }

        public void AddTransaction(Transaction transaction)
        {
            _context.Transaction.Add(transaction);
        }

        public void UpdateAccount(Domain.Models.Account account)
        {
            _context.Account.Update(account);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}