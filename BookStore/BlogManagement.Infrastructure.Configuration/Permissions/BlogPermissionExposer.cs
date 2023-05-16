using _0_Framework.Infrastucture;
using System.Collections.Generic;

namespace BlogManagement.Infrastructure.Configuration.Permissions
{
    public class BlogPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "Article",new List<PermissionDto>
                    {
                        new PermissionDto(BlogPermissions.ListArticles,"لیست"),
                        new PermissionDto(BlogPermissions.SearchArticles,"جستجو"),
                        new PermissionDto(BlogPermissions.CreateArticle,"ایجاد"),
                        new PermissionDto(BlogPermissions.EditArticle,"ویرایش"),
                    }
                },
                {
                    "ArticleCategory",new List<PermissionDto>
                    {
                        new PermissionDto(BlogPermissions.ListArticleCategories,"لیست"),
                        new PermissionDto(BlogPermissions.SearchArticleCategories,"جستجو"),
                        new PermissionDto(BlogPermissions.CreateArticleCategory,"ایجاد"),
                        new PermissionDto(BlogPermissions.EditArticleCategory,"ویرایش"),
                    }
                }
            };
        }
    }
}
