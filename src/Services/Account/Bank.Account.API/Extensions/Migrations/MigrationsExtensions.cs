using Bank.Account.Data;
using Bank.Account.Domain.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Bank.Account.API.Extensions.Migrations
{
    public static class MigrationsExtensions
    {
        public static void Migrate(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<AccountContext>())
                {
                    context.Database.Migrate();
                }
            }
        }

        private static void SeedAccount(AccountContext context)
        {
            System.Console.WriteLine("Aplicando a migração");
            context.Database.Migrate();
        }
    }
}