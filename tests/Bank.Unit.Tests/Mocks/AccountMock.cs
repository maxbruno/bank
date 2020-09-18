using Bank.Account.Application.ViewModels;
using Bogus;
namespace Bank.Unit.Tests.Mocks
{
    public static class AccountMock
    {
         public static Faker<Account.Domain.Models.Account> AccountModelFaker =>
            new Faker<Account.Domain.Models.Account>()
            .CustomInstantiator(x => new Account.Domain.Models.Account
            (
                x.Finance.Account(8),
                x.Finance.Account(7),
                x.Person.UserName,
                x.Finance.Amount(0,50)
            ));
         
         public static Faker<AccountViewModel> AccountViewModelModelFaker =>
             new Faker<AccountViewModel>()
                 .RuleFor(x => x.Id, f => f.Random.Guid())
                 .RuleFor(x => x.AgencyNumber, f => f.Finance.Account(8))
                 .RuleFor(x => x.AgencyNumber, f => f.Finance.Account(7))
                 .RuleFor(x => x.AccountBalance, f => f.Finance.Amount(0,50))
                 .RuleFor(x => x.AccountHolder, f => f.Person.UserName);
    }
}