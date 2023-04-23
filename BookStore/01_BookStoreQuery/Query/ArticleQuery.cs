using _0_Framework.Application;
using _01_BookStoreQuery.Contracts.Article;
using BlogManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_BookStoreQuery.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogContext _blogContext;

        public ArticleQuery(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public ArticleQueryModel GetArticleDetails(string slug)
        {
            var article= _blogContext.Articles.Include(x => x.Category).
                Where(x => x.PublishDate <= DateTime.Now).
                Select(x => new ArticleQueryModel
                {
                    Title = x.Title,
                    ShortDescription = x.ShortDescription,
                    Description = x.Description,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    PublishDate = x.PublishDate.ToFarsi(),
                    Slug = x.Slug,
                    MetaDescription = x.MetaDescription,
                    Keywords = x.Keywords,
                    CanonicalAddress = x.CanonicalAddress,
                    CategoryName = x.Category.Name,
                    CategorySlug = x.Category.Slug
                }).FirstOrDefault(x=>x.Slug==slug);

            article.KeywordList = article.Keywords.Split(",").ToList();
            return article;
        }

        public List<ArticleQueryModel> LatestArticles()
        {
            return _blogContext.Articles.Include(x => x.Category).
                Where(x => x.PublishDate <= DateTime.Now).
                Select(x => new ArticleQueryModel
            {
                Id= x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PublishDate = x.PublishDate.ToFarsi(),
                Slug = x.Slug,
            }).AsNoTracking().OrderByDescending(x=>x.Id).Take(6).ToList();
        }
    }
}
