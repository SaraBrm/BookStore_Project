using _0_Framework.Infrastucture;
using System.Collections.Generic;

namespace DiscountManagement.Configuration.Permissions
{
    public class DiscountPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "Colleague",new List<PermissionDto>
                    {
                        new PermissionDto(DiscountPermissions.ListColleague,"لیست"),
                        new PermissionDto(DiscountPermissions.SearchColleague,"جستجو"),
                        new PermissionDto(DiscountPermissions.DefineColleague,"تعریف"),
                        new PermissionDto(DiscountPermissions.EditColleague,"ویرایش"),
                        new PermissionDto(DiscountPermissions.RemoveColleague,"غیر فعال"),
                        new PermissionDto(DiscountPermissions.RestoreColleague,"فعال سازی"),
                    }
                },
                {
                    "Customer",new List<PermissionDto>
                    {
                        new PermissionDto(DiscountPermissions.ListCustomers,"لیست"),
                        new PermissionDto(DiscountPermissions.SearchCustomers,"جستجو"),
                        new PermissionDto(DiscountPermissions.DefineCustomer,"تعریف"),
                        new PermissionDto(DiscountPermissions.EditCustomer,"ویرایش"),
                    }
                }
            };
        }
    }
}
