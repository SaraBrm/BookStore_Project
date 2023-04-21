using _0_Framework.Application;
using _0_Framework.Infrastucture;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BlogManagement.Infrastructure.EFCore.Repository
{
    public class ArticleRepository : RepositoryBase<long, Article>, IArticleRepository
    {
        private readonly BlogContext _blogContext;

        public ArticleRepository(BlogContext blogContext):base(blogContext)
        {
            _blogContext = blogContext;
        }

        public EditArticle GetDetails(long id)
        {
            return _blogContext.Articles.Select(x => new EditArticle
            {
                Id = x.Id,
                CanonicalAddress = x.CanonicalAddress,
                CategoryId = x.CategoryId,
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PublishDate = x.PublishDate.ToFarsi(),
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
                Title = x.Title
            }).FirstOrDefault(x => x.Id == id);
        }

        public Article GetWithCategory(long id)
        {
            return _blogContext.Articles.
                Include(x=>x.Category).FirstOrDefault(x=> x.Id == id);
        }

        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            var query = _blogContext.Articles.Select(x => new ArticleViewModel
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                Picture = x.Picture,
                PublishDate = x.PublishDate.ToFarsi(),
                Category = x.Category.Name
            });

            if(!string.IsNullOrWhiteSpace(searchModel.Title))
                query=query.Where(x=>x.Title.Contains(searchModel.Title));

            if(searchModel.CategoryId>0)
                query=query.Where(x=>x.CategoryId==searchModel.CategoryId);

            return query.OrderByDescending(x=>x.Id).ToList();
        }
    }
}
