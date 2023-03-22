using System.Collections.Generic;

namespace _01_BookStoreQuery.Contracts.ProductCategory
{
    public interface IProductCategoryQuery
    {
        List<ProductCategoryQueryModel> GetProductCategories();
    }
}
