using Bank.Account.Domain.Interfaces;

namespace Bank.Account.Domain.Enums
{
    public enum ETransactionType : ushort
    {
        Debit = 1,
        Deposit = 2,
        Transfer = 3,
        BankIncome = 4
    }
}