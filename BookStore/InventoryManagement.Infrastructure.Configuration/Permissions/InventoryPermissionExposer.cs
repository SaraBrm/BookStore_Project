using _0_Framework.Infrastucture;
using System.Collections.Generic;

namespace InventoryManagement.Infrastructure.Configuration.Permissions
{
    public class InventoryPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "Product",new List<PermissionDto>
                    {
                        new PermissionDto(50,"ListInventory"),
                        new PermissionDto(51,"SearchInventory"),
                        new PermissionDto(52,"CreateInventory"),
                        new PermissionDto(23,"EditInventory"),
                    }
                }
            };
        }
    }
}
