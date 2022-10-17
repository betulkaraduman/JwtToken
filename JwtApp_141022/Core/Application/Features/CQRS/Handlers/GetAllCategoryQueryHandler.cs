using AutoMapper;
using JwtApp_141022.Core.Application.Dtos;
using JwtApp_141022.Core.Application.Features.CQRS.Queries;
using JwtApp_141022.Core.Application.Interfaces;
using JwtApp_141022.Core.Domain;
using MediatR;

namespace JwtApp_141022.Core.Application.Features.CQRS.Handlers
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, List<CategoryListDto>>
    {
        private readonly IRepository<Category> _repoCategory;
        private readonly IMapper _mapper;
        public GetAllCategoryQueryHandler(IRepository<Category> repoCategory,IMapper mapper)
        {
            _mapper= mapper;
            _repoCategory = repoCategory;
        }

        public async Task<List<CategoryListDto>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repoCategory.GetAllAsync();
            var dto=_mapper.Map<List<CategoryListDto>>(data);
            return dto;
        }
    }
}
