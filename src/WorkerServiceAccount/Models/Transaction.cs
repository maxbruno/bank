using System;
using Newtonsoft.Json;

namespace WorkerServiceAccount.Models
{
    public class Transaction
    {
        public Transaction(ETransactionType transactionType, decimal value, Guid accountId)
        {
            TransactionType = transactionType;
            Value = value;
            AccountId = accountId;
        }

        [JsonProperty(PropertyName = "transactionType")]
        public ETransactionType TransactionType { get; private set; }

        [JsonProperty(PropertyName = "value")] public decimal Value { get; private set; }

        [JsonProperty(PropertyName = "accountId")]

        public Guid AccountId { get; private set; }
    }
}