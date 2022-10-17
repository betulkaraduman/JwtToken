using MediatR;

namespace JwtApp_141022.Core.Application.Features.CQRS.Commands
{
    public class UpdateProductCommamdRequest:IRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
