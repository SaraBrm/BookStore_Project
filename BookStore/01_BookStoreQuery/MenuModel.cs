using _01_BookStoreQuery.Contracts.ArticleCategory;
using _01_BookStoreQuery.Contracts.ProductCategory;
using System.Collections.Generic;

namespace _01_BookStoreQuery
{
    public class MenuModel
    {
        public List<ArticleCategoryQueryModel> ArticleCategories { get; set; }
        public List<ProductCategoryQueryModel> ProductCategories { get; set; }
    }
}
