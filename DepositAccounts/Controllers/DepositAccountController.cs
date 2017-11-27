using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DepositAccounts.Controllers
{
    [Route("api/[controller]")]
    public class DepositAccountController : Controller
    {
        private Infrastructure.AccountContext accountRepository;

        public DepositAccountController(Infrastructure.AccountContext accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        
        /// <summary>
        /// Returns complete list of accounts
        /// </summary>
        /// <returns>List of accounts</returns>
        [HttpGet]
        public IEnumerable<Models.Account> Get()
        {
            return accountRepository.Accounts.ToList();
        }

        /// <summary>
        /// Returns a single account that matches id supplied
        /// </summary>
        /// <param name="id">the Id of account to return</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Models.Account), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var account = await accountRepository.Accounts.SingleOrDefaultAsync(x => x.AccountID == id);

            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        /// <summary>
        /// Creates a new account
        /// </summary>
        /// <param name="Account">The new account to create</param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.Account Account)
        {
            var profile = await accountRepository.Profiles
               .SingleOrDefaultAsync(x => x.ProfileID == Account.ProfileID);

            if (profile == null)
            {
                return BadRequest($"Cannot add account to Profile ({Account.ProfileID}). Profile is in an invalid state.");
            }

            accountRepository.Accounts.Add(Account);
            await accountRepository.SaveChangesAsync();

            return Created("{id:guid}", Account);
        }        
    }
}
