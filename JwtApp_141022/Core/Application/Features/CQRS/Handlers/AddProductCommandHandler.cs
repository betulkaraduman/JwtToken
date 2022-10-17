using JwtApp_141022.Core.Application.Features.CQRS.Commands;
using JwtApp_141022.Core.Application.Interfaces;
using JwtApp_141022.Core.Domain;
using MediatR;

namespace JwtApp_141022.Core.Application.Features.CQRS.Handlers
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest>
    {
        private readonly IRepository<Product> _repoProduct;
        public AddProductCommandHandler(IRepository<Product> repoProduct)
        {
            _repoProduct = repoProduct;
        }

        public async Task<Unit> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _repoProduct.CreateAsync(new Product()
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
                CategoryId = request.CategoryId,
            });
            return Unit.Value;
        }
    }
}
