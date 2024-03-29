﻿using _0_Framework.Domain;
using AcountManagement.Application.Contracts.Account;
using System.Collections.Generic;

namespace AccountManagement.Domain.AccountAgg
{
    public interface IAccountRepository:IRepository<long, Account>
    {
        EditAccount GetDetails(long id);
        List<AccountViewModel> Search(AccountSearchModel searchModel);
        Account GetBy(string username);
        List<AccountViewModel>GetAccounts();
    }
}
