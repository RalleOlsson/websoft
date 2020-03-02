using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using webapp.Models;
using webapp.Services;

namespace webapp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public JsonFileAccountService accountService;

        public IEnumerable<Account> accounts { get; private set; }

        public IndexModel(
            ILogger<IndexModel> logger,
            JsonFileAccountService accountService) {
            _logger = logger;
            this.accountService = accountService;
        }

        public void OnGet()
        {
            accounts = accountService.GetAccounts();
        }
    }
}
