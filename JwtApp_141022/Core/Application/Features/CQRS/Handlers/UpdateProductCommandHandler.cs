using JwtApp_141022.Core.Application.Features.CQRS.Commands;
using JwtApp_141022.Core.Application.Interfaces;
using JwtApp_141022.Core.Domain;
using MediatR;

namespace JwtApp_141022.Core.Application.Features.CQRS.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommamdRequest>
    {
        private readonly IRepository<Product> _repoProduct;
        public UpdateProductCommandHandler(IRepository<Product> repoProduct)
        {
            _repoProduct = repoProduct;
        }

        public async Task<Unit> Handle(UpdateProductCommamdRequest request, CancellationToken cancellationToken)
        {
            var data =await _repoProduct.GetByIdAsync(request.Id);
            if (data != null)
            {
                data.Name = request.Name;
                data.Price = request.Price;
                data.Stock = request.Stock;
                data.CategoryId = request.CategoryId;
               await _repoProduct.UpdateAsync(data);

            }
            return Unit.Value;
        }
    }
}
