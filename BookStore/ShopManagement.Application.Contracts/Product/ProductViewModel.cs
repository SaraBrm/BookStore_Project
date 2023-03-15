namespace ShopManagement.Application.Contracts.Product
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Translator { get; set; }
        public string Publication { get; set; }
        public string Picture { get; set; }
        public string Category { get; set; }
    }
}
