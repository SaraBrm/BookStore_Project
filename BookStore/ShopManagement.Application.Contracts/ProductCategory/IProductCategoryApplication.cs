﻿using _0_Framework.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {
        OperationResult Create(CreateProductCategory command);
        OperationResult Edit (EditProductCategory command);
        EditProductCategory GetDetails(long id);
        List<ProducrCategoryViewModel> Search(ProductCategorySearchModel searchModel);
        List<ProducrCategoryViewModel> GetProductCategories();
    }
}
