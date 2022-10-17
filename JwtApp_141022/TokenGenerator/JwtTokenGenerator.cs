using JwtApp_141022.Core.Application.Dtos;
using JwtApp_141022.Core.Domain;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtApp_141022.TokenGenerator
{
    public class JwtTokenGenerator
    {
        public JwtTokenResponse GenerateToken(CheckUserResponseDto userDto)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenSettings.Key));
            SigningCredentials credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, userDto.Role));
            claims.Add(new Claim(ClaimTypes.Name, userDto?.Username));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, userDto.Id.ToString()));

            var expireDate = DateTime.UtcNow.AddDays(1);
            //UTC Noe ile banlama işlemlerinden lokasyon değişikliği ile banı kaldırma önlenmiş olur
            JwtSecurityToken token = new JwtSecurityToken(issuer:JwtTokenSettings.Issuer,audience:JwtTokenSettings.Audience,claims:claims,notBefore:DateTime.UtcNow ,expires: expireDate,signingCredentials:credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return new JwtTokenResponse(handler.WriteToken(token), expireDate);
         }
    }
}
