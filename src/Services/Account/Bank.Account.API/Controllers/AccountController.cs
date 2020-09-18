using System.Collections.Generic;
using System.Threading.Tasks;
using Bank.Account.Application.Services;
using Bank.Account.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace Bank.Account.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountAppService _accountAppService;

        public AccountController(IAccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountViewModel>>> GetAll()
        {
            return Ok(await _accountAppService.GetAll());
        }
        
        [HttpGet("transactions/{accountId}")]
        public async Task<ActionResult<IEnumerable<TransactionViewModel>>> GetById([FromQuery]AccountIdViewModel account)
        {
            var transactionViewModel  = await _accountAppService.GetByAccountId(account.AccountId);

            if (!transactionViewModel.Any()) return NotFound();

            return Ok(transactionViewModel);
        }

        [HttpPost]
        public async Task<ActionResult<TransactionViewModel>> Post([FromBody]TransactionInputViewModel transaction)
        {
            if (transaction == null) return NotFound();

            var transactionViewModel = await _accountAppService.Transaction(transaction);
            
            return Created(nameof(GetById), new AccountIdViewModel(transactionViewModel.AccountId));
        }
    }
}