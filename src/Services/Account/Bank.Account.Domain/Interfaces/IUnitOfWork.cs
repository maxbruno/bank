using System;
using System.Threading.Tasks;

namespace Bank.Account.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
         Task<bool> Commit();
    }
}