namespace JwtApp_141022.Core.Domain
{
    public class Product : BaseClass
    {
        public string? Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public Product()
        {
            Category = new Category();
        }

    }
}
