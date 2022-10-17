using JwtApp_141022.Core.Application.Features.CQRS.Commands;
using JwtApp_141022.Core.Application.Features.CQRS.Queries;
using JwtApp_141022.TokenGenerator;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace JwtApp_141022.Controllers
{

    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterUserWithMemberCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("", "");

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn(CheckUserQueryRequest request)
        {
            var user = await _mediator.Send(request);
            if (user.IsExist)
            {
                JwtTokenGenerator jwtTokenGenerator = new JwtTokenGenerator();
               var token= jwtTokenGenerator.GenerateToken(user);
                return Ok(token);
            }
            return BadRequest();
        }
    }
}
