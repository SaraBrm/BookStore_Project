using System.Collections.Generic;

namespace _01_BookStoreQuery.Contracts.Article
{
    public interface IArticleQuery
    {
        List<ArticleQueryModel> LatestArticles();
    }
}
