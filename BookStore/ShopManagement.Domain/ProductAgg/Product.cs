using _0_Framework.Domain;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product:EntityBase
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Author { get; private set; }
        public string Translator { get; private set; }
        public string Publication { get; private set; }
        public double UnitPrice { get; private set; }
        public bool IsInStock { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public long CategoryId { get; private set; }
        public ProductCategory Category { get; private set; }

        public Product(string code, string name, string author, string translator, 
            string publication, double unitPrice, string shortDescription, 
            string description, string picture, string pictureAlt, string pictureTitle, 
            string slug, string keywords, string metaDescription, long categoryId)
        {
            Code = code;
            Name = name;
            Author = author;
            Translator = translator;
            Publication = publication;
            UnitPrice = unitPrice;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CategoryId = categoryId;
            IsInStock = true;
        }

        public void Edit(string code, string name, string author, string translator,
            string publication, double unitPrice, string shortDescription,
            string description, string picture, string pictureAlt, string pictureTitle,
            string slug, string keywords, string metaDescription, long categoryId)
        {
            Code = code;
            Name = name;
            Author = author;
            Translator = translator;
            Publication = publication;
            UnitPrice = unitPrice;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CategoryId = categoryId;
        }

        public void InStock()
        {
            IsInStock = true;
        }

        public void NotInStock()
        {
            IsInStock=false;
        }

    }
}
