using JwtApp_141022.Core.Application.Dtos;
using JwtApp_141022.Core.Application.Features.CQRS.Queries;
using JwtApp_141022.Core.Application.Interfaces;
using JwtApp_141022.Core.Domain;
using MediatR;

namespace JwtApp_141022.Core.Application.Features.CQRS.Handlers
{
    public class CheckUserQueryHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto>
    {
        private readonly IRepository<AppRole> _roleRepo;
        private readonly IRepository<AppUser> _userRepo;
        public CheckUserQueryHandler(IRepository<AppUser> userRepo, IRepository<AppRole> roleRepo)
        {
            _userRepo = userRepo;
            _roleRepo = roleRepo;
        }

        public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = new CheckUserResponseDto();
            var user = await _userRepo.GetByFilterAsync(i => i.Username == request.Username && i.Password == request.Password);
            if (user == null)
                dto.IsExist = false;
            else
            {
                dto.Username = user.Username;
                dto.Id = user.Id;
                dto.IsExist = true;
                var role = await _roleRepo.GetByFilterAsync(i => i.Id == user.AppRoleId);
                dto.Role = role?.Definition;
            }
            return dto;
        }
    }
}
