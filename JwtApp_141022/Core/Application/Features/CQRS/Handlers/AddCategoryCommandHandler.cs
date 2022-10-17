using JwtApp_141022.Core.Application.Features.CQRS.Commands;
using JwtApp_141022.Core.Application.Interfaces;
using JwtApp_141022.Core.Domain;
using MediatR;

namespace JwtApp_141022.Core.Application.Features.CQRS.Handlers
{
    public class AddCategoryCommandHandler: IRequestHandler<AddCategoryCommandRequest>
    {
        private readonly IRepository<Category> _repoCategory;
        public AddCategoryCommandHandler(IRepository<Category> repoCategory)
        {
            _repoCategory = repoCategory;
        }

        public async Task<Unit> Handle(AddCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _repoCategory.CreateAsync(new Category()
            {
                Definition = request.Definition
            });
            return Unit.Value;
        }
    }
}
