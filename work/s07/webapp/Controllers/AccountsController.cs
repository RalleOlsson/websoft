using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webapp.Models;
using webapp.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;


namespace webapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class AccountsController : ControllerBase
    {
        public AccountsController(JsonFileAccountService accountService)
        {
            this.accountService = accountService;
        }

        public JsonFileAccountService accountService { get; }

        [HttpGet]
        public IEnumerable<Account> Get()
        {
            return accountService.GetAccounts();
        }

        [HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Account> GetById(int id) {
            Account result = null;

            foreach (var account in accountService.GetAccounts()) {
                if (account.Number == id) {
                    result = account;
                }
            }
            
            if (result == null) {
                return NotFound();
            }
            
            return result;
    
        }

        /*
        // Create method
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Account> Create(Account newAccount) {
            var accounts = accountService.GetAccounts();
            
            List<Account> list = new List<Account>();

            foreach (var account in accounts) {
                list.Add(account);
            }

            list.Add(newAccount);
            
            accountService.SaveAccounts(list);

            return CreatedAtAction(nameof(GetById), new { id = newAccount.Number }, newAccount);
        }*/

        // takes two accounts and moves the balance from the first account to the other
        [HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<Account> Update(IEnumerable<Account> moveAccounts) {
            
            var accounts = accountService.GetAccounts();
            
            List<Account> list = new List<Account>();
            moveAccounts.ElementAt(0);
            Account postAccFrom = moveAccounts.ElementAt(0);
            Account postAccTo = moveAccounts.ElementAt(1);

            Account from = null;
            Account to = null;

            foreach(var account in accounts) {
                if (postAccFrom.Number == account.Number)
                    from = account;
                else if (postAccTo.Number == account.Number)
                    to = account; 
            }

            if (from != null && to != null) {
                to.Balance += from.Balance;
                from.Balance = 0;
            }

            accountService.SaveAccounts(accounts);
            
            //accountService.SaveAccounts(accounts);

            return accounts;
        }

    }
}
