﻿using BankApp2.Shared.ModelsNotInDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp2.Core.Interfaces
{
    public interface IJwtTokenService
    {
        Task<string> CreateJwtToken(UserLoginDto user);
    };
}
