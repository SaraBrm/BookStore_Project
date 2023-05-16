using _0_Framework.Infrastucture;
using System.Collections.Generic;

namespace ShopManagement.Configuration.Permissions
{
    public class ShopPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "Book",new List<PermissionDto>
                    {
                        new PermissionDto(ShopPermissions.ListProducts,"لیست"),
                        new PermissionDto(ShopPermissions.SearchProducts,"جستجو"),
                        new PermissionDto(ShopPermissions.CreateProduct,"ایجاد"),
                        new PermissionDto(ShopPermissions.EditProduct,"ویرایش"),
                    }
                },
                {
                    "BookCategory",new List<PermissionDto>
                    {
                        new PermissionDto(ShopPermissions.ListProductCategories,"لیست"),
                        new PermissionDto(ShopPermissions.SearchProductCategories,"جستجو"),
                        new PermissionDto(ShopPermissions.CreateProductCategory,"ایجاد"),
                        new PermissionDto(ShopPermissions.EditProductCategory,"ویرایش"),
                    }
                },
                {
                    "Slider",new List<PermissionDto>
                    {
                        new PermissionDto(ShopPermissions.ListSlides,"لیست"),
                        new PermissionDto(ShopPermissions.CreateSlide,"ایجاد"),
                        new PermissionDto(ShopPermissions.EditSlide,"ویرایش"),
                        new PermissionDto(ShopPermissions.RemoveSlide,"حذف"),
                        new PermissionDto(ShopPermissions.RestoreSlide,"فعال سازی"),
                    }
                },
                {
                    "BookPictures",new List<PermissionDto>
                    {
                        new PermissionDto(ShopPermissions.ListProductPictures,"لیست"),
                        new PermissionDto(ShopPermissions.SearchProductPicture,"جستجو"),
                        new PermissionDto(ShopPermissions.CreateProductPicture,"ایجاد"),
                        new PermissionDto(ShopPermissions.EditProductPicture,"ویرایش"),
                        new PermissionDto(ShopPermissions.RemoveProductPicture,"حذف"),
                        new PermissionDto(ShopPermissions.RestoreProductPicture,"فعال سازی"),
                    }
                }
            };
        }
    }
}
