namespace ShopManagement.Application.Contracts.Product
{
    public class ProductSearchModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public long CategoryId { get; set; }
    }
}
