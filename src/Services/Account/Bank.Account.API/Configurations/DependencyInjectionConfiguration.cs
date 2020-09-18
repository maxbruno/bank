using Bank.Account.Application.Services;
using Bank.Account.Data;
using Bank.Account.Data.Repositories;
using Bank.Account.Domain.Interfaces;
using Bank.Account.Domain.Notifications;
using Bank.Account.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Bank.Account.API.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDiConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IAccountAppService, AccountAppService>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            
            services.AddScoped<IDomainNotification, DomainNotification>();
            services.AddScoped<ITransactionService, TransactionService>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}