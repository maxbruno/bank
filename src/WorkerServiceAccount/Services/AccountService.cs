using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WorkerServiceAccount.Models;

namespace WorkerServiceAccount.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;
        private ILogger<AccountService> _logger;

        public AccountService(HttpClient httpClient, ILogger<AccountService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            var response = await _httpClient.GetAsync($"api/Account");
            var stringResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Account>>(stringResponse);
        }

        public async Task SendTransaction(Transaction transaction)
        {
            var content = JsonConvert.SerializeObject(transaction);
            var httpResponse = await _httpClient.PostAsync("api/Account",
                new StringContent(content, Encoding.Default, "application/json"));

            _logger.LogInformation(
                !httpResponse.IsSuccessStatusCode
                    ? $"Não foi possível realizar a transação {transaction.TransactionType} para a contra {transaction.AccountId}"
                    : $"Transação realizada com sucesso!");
        }
    }
}