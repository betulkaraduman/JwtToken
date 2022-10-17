using JwtApp_141022.Core.Application.Dtos;
using MediatR;

namespace JwtApp_141022.Core.Application.Features.CQRS.Queries
{
    public class GetAllCategoryQueryRequest:IRequest<List<CategoryListDto>>
    {
    }
}
