using JwtApp_141022.Core.Domain;

namespace JwtApp_141022.Core.Application.Dtos
{
    public class ProductListDto:BaseClass
    {
        public string? Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
