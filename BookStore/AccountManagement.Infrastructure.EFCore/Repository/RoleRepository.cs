using _0_Framework.Application;
using AccountManagement.Domain.RoleAgg;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using _0_Framework.Infrastucture;
using AccountManagement.Infrastructure.EFCore;
using AcountManagement.Application.Contracts.Role;

namespace AccountMangement.Infrastructure.EFCore.Repository
{
    public class RoleRepository : RepositoryBase<long, Role>, IRoleRepository
    {
        private readonly AccountContext _accountContext;

        public RoleRepository(AccountContext accountContext) : base(accountContext)
        {
            _accountContext = accountContext;
        }

        public EditRole GetDetails(long id)
        {
            return _accountContext.Roles.Select(x => new EditRole
                {
                    Id = x.Id,
                    Name = x.Name
                }).AsNoTracking().FirstOrDefault(x => x.Id == id);

        }

        public List<RoleViewModel> List()
        {
            return _accountContext.Roles.Select(x => new RoleViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate=x.CreationDate.ToFarsi()
            }).ToList();
        }
    }
}