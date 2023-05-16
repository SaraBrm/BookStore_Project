namespace ShopManagement.Configuration.Permissions
{
    public static class ShopPermissions
    {
        //Book
        public const int ListProducts = 10;
        public const int SearchProducts = 11;
        public const int CreateProduct = 12;
        public const int EditProduct = 13;


        //BookCategory
        public const int ListProductCategories = 20;
        public const int SearchProductCategories = 21;
        public const int CreateProductCategory = 22;
        public const int EditProductCategory = 23;


        //Slide
        public const int ListSlides = 30;
        public const int CreateSlide = 31;
        public const int EditSlide = 32;
        public const int RemoveSlide = 33;
        public const int RestoreSlide = 34;


        //BookPictures
        public const int ListProductPictures = 40;
        public const int SearchProductPicture = 41;
        public const int CreateProductPicture = 42;
        public const int EditProductPicture = 43;
        public const int RemoveProductPicture = 44;
        public const int RestoreProductPicture = 45;

    }
}