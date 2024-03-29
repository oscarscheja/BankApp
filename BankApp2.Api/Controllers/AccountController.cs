﻿using BankApp2.Core.Interfaces;
using BankApp2.Shared.Models;
using BankApp2.Shared.ModelsNotInDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankApp2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IDispositionService _dispositionService;

        public AccountController(IAccountService accountService, IDispositionService dispositionService)
        {
            _accountService = accountService;
            _dispositionService = dispositionService;
        }

        [HttpPost]
        public async Task<ActionResult<Account>> Register(AccountModel account)
        {
            try
            {
                if (account == null)
                {
                    return BadRequest("Felaktiga kontouppgifter");
                }
                var returnedAccount = await _accountService.CreateAccount(account);
                if (returnedAccount != null)
                {
                    var returnedDisposition = await _dispositionService.CreateDisposition(
                        account.CustomerId, returnedAccount.AccountId, account.DispositionsType);

                    if (returnedDisposition != null)
                    {
                        return Ok(returnedAccount);
                    }
                    else
                    {
                        return BadRequest("Gick inte att skapa disposition");
                    }
                }
                else
                {
                    return BadRequest("Gick inte att skapa konto");
                }

            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");    
            }
            
         }
        [Authorize]
        [HttpGet("{accountId}")]
        public async Task<ActionResult<Account>> GetAccount(int accountId)
        {
            try
            {
                var result = await _accountService.GetAccount(accountId);
                if(result != null)
                {
                    return Ok(result);
                }
                return BadRequest("Gick inte att hämta konto");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }


    }
}
