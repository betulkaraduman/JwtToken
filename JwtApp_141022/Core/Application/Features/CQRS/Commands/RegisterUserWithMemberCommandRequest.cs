using MediatR;

namespace JwtApp_141022.Core.Application.Features.CQRS.Commands
{
    public class RegisterUserWithMemberCommandRequest:IRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
