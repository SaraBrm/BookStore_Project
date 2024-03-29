﻿
using _01_BookStoreQuery;
using _01_BookStoreQuery.Contracts.ArticleCategory;
using _01_BookStoreQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;


namespace ServiceHost.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;
        private readonly IArticleCategoryQuery _articleCategoryQuery;

        public MenuViewComponent(IProductCategoryQuery productCategoryQuery, IArticleCategoryQuery articleCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
            _articleCategoryQuery = articleCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var result = new MenuModel
            {
                ProductCategories = _productCategoryQuery.GetProductCategories(),
                ArticleCategories = _articleCategoryQuery.GetArticleCategories()
            };
            return View(result);
        }
    }
}
