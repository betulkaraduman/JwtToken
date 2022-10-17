using JwtApp_141022.Core.Application.Features.CQRS.Commands;
using JwtApp_141022.Core.Application.Interfaces;
using JwtApp_141022.Core.Domain;
using MediatR;

namespace JwtApp_141022.Core.Application.Features.CQRS.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommantRequest>
    {
        private readonly IRepository<Product> _repoProduct;
        public DeleteProductCommandHandler(IRepository<Product> repoProduct)
        {
            _repoProduct = repoProduct;
        }

        public async Task<Unit> Handle(DeleteProductCommantRequest request, CancellationToken cancellationToken)
        {
            await _repoProduct.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
