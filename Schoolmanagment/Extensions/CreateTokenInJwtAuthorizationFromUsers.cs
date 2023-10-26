using System.IdentityModel.Tokens.Jwt;
using System.Security;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Schoolmanagment.Date;
using Schoolmanagment.Entities;

namespace Schoolmanagment.Extensions;
public class CreateTokenInJwtAuthorizationFromUsers
{
    public static readonly IHttpContextAccessor httpContextAccessor;
    public static string CreateToken(User user,List<Claim> claims)
    {
        claims.Add(new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()));
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asfsafsasafjsafjksafksafsafsafsafasfasfafasfsafasfsafsafassaf"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(7),
            signingCredentials:creds,
            issuer: "http://localhost:5069/"
            );
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }
}
