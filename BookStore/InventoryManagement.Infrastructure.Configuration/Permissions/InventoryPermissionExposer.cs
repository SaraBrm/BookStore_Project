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
                    "Inventory",new List<PermissionDto>
                    {
                        new PermissionDto(InventoryPermissions.ListInventory,"لیست"),
                        new PermissionDto(InventoryPermissions.SearchInventory,"جستجو"),
                        new PermissionDto(InventoryPermissions.CreateInventory,"ایجاد"),
                        new PermissionDto(InventoryPermissions.EditInventory,"ویرایش"),
                        new PermissionDto(InventoryPermissions.Increase, "افزایش"),
                        new PermissionDto(InventoryPermissions.Reduce, "کاهش"),
                        new PermissionDto(InventoryPermissions.OperationLog, "گزارش")
                    }
                }
            };
        }
    }
}
