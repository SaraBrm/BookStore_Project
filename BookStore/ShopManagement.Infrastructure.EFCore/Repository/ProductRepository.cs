using _0_Framework.Application;
using _0_Framework.Infrastucture;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductRepository : RepositoryBase<long, Product>, IProductRepository
    {
        private readonly ShopContext _context;

        public ProductRepository(ShopContext context):base(context)
        {
            _context = context;
        }

        public EditProduct GetDetails(long id)
        {
            return _context.Products.Select(x=>new EditProduct
            {
                Id = x.Id,
                Code=x.Code,
                Name=x.Name,
                Author=x.Author,
                Translator=x.Translator,
                Publication=x.Publication,
                ShortDescription=x.ShortDescription,
                Description=x.Description,
                PictureAlt=x.PictureAlt,
                PictureTitle=x.PictureTitle,
                Slug=x.Slug,
                Keywords=x.Keywords,
                MetaDescription=x.MetaDescription,
                CategoryId=x.CategoryId
            }).FirstOrDefault(x=>x.Id==id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _context.Products.Select(x=>new ProductViewModel
            {
                Id=x.Id,
                Name=x.Name
            }).ToList();
        }

        public Product GetProductWithCategory(long id)
        {
             return _context.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var query = _context.Products.Include(x => x.Category).Select(x => new ProductViewModel
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                Author = x.Author,
                Translator = x.Translator,
                Publication = x.Publication,
                Picture = x.Picture,
                Category = x.Category.Name,
                CategoryId = x.CategoryId,
                CreationDate=x.CreationDate.ToFarsi()
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Code))
                query = query.Where(x => x.Code.Contains(searchModel.Code));

            if (!string.IsNullOrWhiteSpace(searchModel.Author))
                query = query.Where(x => x.Author.Contains(searchModel.Author));

            if(searchModel.CategoryId!=0)
                query=query.Where(x=>x.CategoryId==searchModel.CategoryId);

            return query.OrderByDescending(x=>x.Id).ToList();
        }
    }
}
