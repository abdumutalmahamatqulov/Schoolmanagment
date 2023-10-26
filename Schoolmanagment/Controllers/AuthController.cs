using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schoolmanagment.Dto_s;
using Schoolmanagment.Entities;
using Schoolmanagment.Services;

namespace Schoolmanagment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService) => _authService = authService;
    [HttpGet("ListUsers"), Authorize]
    public async Task<IActionResult> GetAllUsers() => Ok(await _authService.UserList());
    [HttpPost("registor")]
    public async Task<ActionResult<User>> Regisotr(UserDto request)
    {
        return Ok(await _authService.Register(request));
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(UserDto request) => Ok(await _authService.Login(request));
}
