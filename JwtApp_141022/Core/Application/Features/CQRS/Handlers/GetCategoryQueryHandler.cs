using AutoMapper;
using JwtApp_141022.Core.Application.Dtos;
using JwtApp_141022.Core.Application.Features.CQRS.Queries;
using JwtApp_141022.Core.Application.Interfaces;
using JwtApp_141022.Core.Domain;
using MediatR;

namespace JwtApp_141022.Core.Application.Features.CQRS.Handlers
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest, CategoryListDto>
    {
        private readonly IRepository<Category> _repoCategory;
        private readonly IMapper _mapper;
        public GetCategoryQueryHandler(IRepository<Category> repoCategory, IMapper mapper)
        {
            _mapper = mapper;
            _repoCategory = repoCategory;
        }

        public async Task<CategoryListDto> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repoCategory.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CategoryListDto>(data);
            return dto; }
    }
}
