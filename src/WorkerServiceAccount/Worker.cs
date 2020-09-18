using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NCrontab;
using Newtonsoft.Json;
using WorkerServiceAccount.Models;
using WorkerServiceAccount.Services;

namespace WorkerServiceAccount
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IAccountService _accountService;
        private CrontabSchedule _schedule;
        private DateTime _nextRun;

        private string Schedule => "*/60 * * * * *";

        public Worker(ILogger<Worker> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
            _schedule = CrontabSchedule.Parse(Schedule, new CrontabSchedule.ParseOptions {IncludingSeconds = true});
            _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                do
                {
                    _logger.LogInformation("Worker executando em: {time}",
                        DateTimeOffset.Now);
                    var now = DateTime.Now;
                    var nextrun = _schedule.GetNextOccurrence(now);
                    if (now > _nextRun)
                    {
                        await Process();
                        _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
                    }

                    await Task.Delay(5000, stoppingToken);
                } while (!stoppingToken.IsCancellationRequested);
            }
        }

        private async Task Process()
        {
            _logger.LogInformation($"Buscando contas.");
            var accounts = await _accountService.GetAllAccounts();

            foreach (var account in accounts)
            {
                _logger.LogInformation($"Iniciando o cálculo para a contra: {account.AccountNumber}");
                var accountAccountBalance = (account.AccountBalance * 0.0101m);
                var transaction = new Transaction(ETransactionType.BankIncome, accountAccountBalance, account.Id);
                _logger.LogInformation($"Valor calculado: {accountAccountBalance}");
                await _accountService.SendTransaction(transaction);
            }
        }
    }
}