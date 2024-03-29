﻿using BankApp2.Data.Interfaces;
using BankApp2.Data.Models;
using BankApp2.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BankApp2.Data.Repos
{
    public class AccountRepo : IAccountRepo
    {

        private readonly BankAppDataContext _db;

        public AccountRepo(BankAppDataContext db)
        {
            _db = db;
        }

        public async Task<Account> CreateAccount(Account account)
        {
            var result = await _db.Accounts.AddAsync(account);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Account> GetAccount(int id)
        {
            return await _db.Accounts.FirstOrDefaultAsync( a => a.AccountId == id);
        }

        public async Task<Account> UpdateAccount(int accountId, decimal amount)
        {
            var result = await GetAccount(accountId);

            if (result != null)
            {
                result.Created = result.Created;
                result.Frequency = result.Frequency;
                result.AccountTypesId = result.AccountTypesId;
                result.Balance = result.Balance + amount;

                await _db.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
