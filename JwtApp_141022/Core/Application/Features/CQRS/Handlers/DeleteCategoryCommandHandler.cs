using JwtApp_141022.Core.Application.Features.CQRS.Commands;
using JwtApp_141022.Core.Application.Interfaces;
using JwtApp_141022.Core.Domain;
using MediatR;

namespace JwtApp_141022.Core.Application.Features.CQRS.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest>
    {
        private readonly IRepository<Category> _repoCategory;
        public DeleteCategoryCommandHandler(IRepository<Category> repoCategory)
        {
            _repoCategory = repoCategory;
        }

        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _repoCategory.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
