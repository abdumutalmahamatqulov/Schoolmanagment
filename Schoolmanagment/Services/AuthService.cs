using System.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Schoolmanagment.Date;
using Schoolmanagment.Dto_s;
using Schoolmanagment.Entities;
using Schoolmanagment.Extensions;

namespace Schoolmanagment.Services;
public class AuthService : IAuthService
{
    private readonly AppDbContext _appDbContext;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthService(UserManager<User> userManager, AppDbContext appDbContext, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _appDbContext = appDbContext;
        _roleManager = roleManager;
    }
    public async Task<List<User>>UserList() => await _appDbContext.Users.ToListAsync();

    public async Task<string> Login(UserDto request)
    {
        var user = await _appDbContext.Users.FirstOrDefaultAsync(x=>x.Email==request.Email);
        if (user != null)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(role=>new Claim(ClaimTypes.Role, role)).ToList();
            roleClaims.Add(new Claim(ClaimTypes.Name, request.Name));
            var token = CreateTokenInJwtAuthorizationFromUsers.CreateToken(user, roleClaims);
            return token;
        }
        throw new BadHttpRequestException("User not Found => Foydalanuvchi topilmadi");
    }

    public async Task<User> Register(UserDto request)
    {
        var user = new User
        {
            Email = request.Email,
            UserName = request.Name,
        };
        var result = await _userManager.CreateAsync(user,request.Password);
        if(!result.Succeeded) 
        {
            throw new Exception("Password is not hashed=>Passwordingiz hashlanmagan");
        }
        await _userManager.AddToRoleAsync(user, Enum.GetName(request.Role).ToUpper());
        await _appDbContext.SaveChangesAsync();
        return user;
    }
}
