﻿using _0_Framework.Infrastucture;
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
                    "Product",new List<PermissionDto>
                    {
                        new PermissionDto(10,"ListProducts"),
                        new PermissionDto(11,"SearchProducts"),
                        new PermissionDto(12,"CreateProduct"),
                        new PermissionDto(13,"EditProduct"),
                    }
                },
                {
                    "ProductCategory",new List<PermissionDto>
                    {
                        new PermissionDto(20,"listProductCategories"),
                        new PermissionDto(21,"SearchProductCategories"),
                        new PermissionDto(22,"CreateProductCategory"),
                        new PermissionDto(23,"EditProductCategory"),
                    }
                }
            };
        }
    }
}
