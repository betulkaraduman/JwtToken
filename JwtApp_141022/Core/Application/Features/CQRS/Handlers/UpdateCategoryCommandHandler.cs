using JwtApp_141022.Core.Application.Features.CQRS.Commands;
using JwtApp_141022.Core.Application.Interfaces;
using JwtApp_141022.Core.Domain;
using MediatR;

namespace JwtApp_141022.Core.Application.Features.CQRS.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest>
    {
        private readonly IRepository<Category> _repoCategory;
        public UpdateCategoryCommandHandler(IRepository<Category> repoCategory)
        {
            _repoCategory = repoCategory;
        }

        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await _repoCategory.GetByIdAsync(request.Id);
            if (data != null)
            {
                data.Definition = request.Definition;
                await _repoCategory.UpdateAsync(data);
            }
            return Unit.Value;
        }
    }
}
