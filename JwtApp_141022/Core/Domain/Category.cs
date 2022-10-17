namespace JwtApp_141022.Core.Domain
{
    public class Category:BaseClass
    {
        public string? Definition { get; set; }
        public List<Product> Products { get; set; }

        public Category()
        {
            Products = new List<Product>(); 
        }
    }
}
