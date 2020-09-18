using Bank.Account.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bank.Account.API.Extensions.Context
{
    public static class RegisterContextsExtensions
    {
        public static void RegisterContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AccountContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Bank.Account.Data")));
        }
    }
}