using System;
using Bank.Account.Domain.Enums;

namespace Bank.Account.Application.ViewModels
{
    public class TransactionInputViewModel
    {
        public ETransactionType TransactionType { get; set; }
        public decimal Value { get; set; }
        public Guid AccountId { get; set; }
    }
}