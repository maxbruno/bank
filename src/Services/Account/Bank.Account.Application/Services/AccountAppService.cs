using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Bank.Account.Application.ViewModels;
using Bank.Account.Domain.Enums;
using Bank.Account.Domain.Interfaces;
using Bank.Account.Domain.Models;
using Bank.Account.Domain.Validations;

namespace Bank.Account.Application.Services
{
    public class AccountAppService : IAccountAppService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly ITransactionService _transactionService;
        private readonly IDomainNotification _notification;

        public AccountAppService(
            IAccountRepository accountRepository,
            IMapper mapper,
            ITransactionService transactionService,
            IDomainNotification notification)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _transactionService = transactionService;
            _notification = notification;
        }

        public async Task<IEnumerable<AccountViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<AccountViewModel>>(await _accountRepository.GetAccounts());
        }

        public async Task<IEnumerable<TransactionViewModel>> GetByAccountId(Guid accountId)
        {
            return _mapper.Map<IEnumerable<TransactionViewModel>>(
                await _accountRepository.GetTransactionsByAccountId(accountId));
        }

        public async Task<TransactionViewModel> Transaction(TransactionInputViewModel transactionVM)
        {
            TransactionViewModel viewModel = null;
            var transaction = _mapper.Map<Transaction>(transactionVM);
            var validation = await new TransactionInsertValidation().ValidateAsync(transaction);

            if (!validation.IsValid)
            {
                _notification.AddNotifications(validation);
                return viewModel;
            }

            switch (transaction.TransactionType)
            {
                case ETransactionType.Debit:
                    await _transactionService.DebitAccount(transaction);
                    break;
                case ETransactionType.Deposit:
                case ETransactionType.BankIncome:
                {
                    await _transactionService.DepositAccount(transaction);
                    break;
                }
                case ETransactionType.Transfer:
                    await _transactionService.TransferAccount(transaction);
                    break;
                default:
                    _notification.AddNotification("transaction", "Tipo de transação não disponível.");
                    return null;
            }

            viewModel = _mapper.Map<TransactionViewModel>(transaction);
            return viewModel;
        }

        public void Dispose()
        {
            _accountRepository?.Dispose();
        }
    }
}