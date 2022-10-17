using JwtApp_141022.Core.Application.Dtos;
using MediatR;

namespace JwtApp_141022.Core.Application.Features.CQRS.Queries
{
    public class CheckUserQueryRequest:IRequest<CheckUserResponseDto>
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; }= string.Empty;
        
    }
}
