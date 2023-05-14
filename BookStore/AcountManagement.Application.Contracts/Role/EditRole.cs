using _0_Framework.Infrastucture;
using System.Collections.Generic;

namespace AcountManagement.Application.Contracts.Role
{
    public class EditRole:CreateRole
    {
        public long Id { get; set; }
        public List<PermissionDto> MappedPermissions { get; set; }
    }
}
