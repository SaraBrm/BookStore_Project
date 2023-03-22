using _01_BookStoreQuery.Contracts.ProductCategory;
using ShopManagement.Infrastructure.EFCore;
using System.Collections.Generic;
using System.Linq;

namespace _01_BookStoreQuery.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _shopContext;

        public ProductCategoryQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<ProductCategoryQueryModel> GetProductCategories()
        {
            return _shopContext.ProductCategories.Select(x=>new ProductCategoryQueryModel
            {
                Id=x.Id,
                Name=x.Name,
                Picture=x.Picture,
                PictureAlt=x.PictureAlt,
                PictureTitle=x.PictureTitle,
                Slug=x.Slug
            }).ToList();
        }
    }
}
