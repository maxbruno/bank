using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Account.Application.ViewModels
{
    public class AccountIdViewModel
    {
        public AccountIdViewModel() { }
        public AccountIdViewModel(Guid accountId)
        {
            AccountId = accountId;
        }

        [FromRoute(Name = "accountId")]
        [Required(ErrorMessage = "O accountId é obrigatório")]
        public Guid AccountId { get; set; }
    }
}