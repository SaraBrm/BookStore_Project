﻿using _0_Framework.Domain;
using AcountManagement.Application.Contracts.Role;
using System.Collections.Generic;

namespace AccountManagement.Domain.RoleAgg
{
    public interface IRoleRepository:IRepository<long,Role>
    {
        List<RoleViewModel> List();
        EditRole GetDetails(long id);
    }
}
