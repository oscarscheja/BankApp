﻿using BankApp2.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp2.Data.Interfaces
{
    public interface ITransactionRepo
    {
        Task<Transaction> GetTransaction(int accountId);
        Task<Transaction> PostTransaction(Transaction transaction);
    }
}
