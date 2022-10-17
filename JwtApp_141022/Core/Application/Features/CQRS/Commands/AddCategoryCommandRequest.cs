using MediatR;

namespace JwtApp_141022.Core.Application.Features.CQRS.Commands
{
    public class AddCategoryCommandRequest : IRequest
    {
        public string? Definition { get; set; }
    }
}
