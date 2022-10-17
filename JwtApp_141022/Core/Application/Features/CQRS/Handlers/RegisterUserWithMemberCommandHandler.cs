using JwtApp_141022.Core.Application.Enums;
using JwtApp_141022.Core.Application.Features.CQRS.Commands;
using JwtApp_141022.Core.Application.Interfaces;
using JwtApp_141022.Core.Domain;
using MediatR;

namespace JwtApp_141022.Core.Application.Features.CQRS.Handlers
{
    public class RegisterUserWithMemberCommandHandler : IRequestHandler<RegisterUserWithMemberCommandRequest>
    {
        private readonly IRepository<AppUser> _userRepo;
        public RegisterUserWithMemberCommandHandler(IRepository<AppUser> userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<Unit> Handle(RegisterUserWithMemberCommandRequest request, CancellationToken cancellationToken)
        {
            await _userRepo.CreateAsync(new AppUser()
            {
                Username = request.Username,
                Password = request.Password,
                AppRoleId = (int)RoleTypes.Member
            }) ;
            return Unit.Value;
        }
    }
}
