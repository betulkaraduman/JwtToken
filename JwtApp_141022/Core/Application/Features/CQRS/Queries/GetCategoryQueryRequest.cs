using JwtApp_141022.Core.Application.Dtos;
using MediatR;

namespace JwtApp_141022.Core.Application.Features.CQRS.Queries
{
    public class GetCategoryQueryRequest:IRequest<CategoryListDto>
    {
        public int Id { get; set; }
        public GetCategoryQueryRequest(int id)
        {
            Id = id;
        }
    }
}
