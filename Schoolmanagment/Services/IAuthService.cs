using Schoolmanagment.Dto_s;
using Schoolmanagment.Entities;

namespace Schoolmanagment.Services;
public interface IAuthService
{
    public Task<User> Register(UserDto request);
    public Task<string> Login(UserDto request);
    public Task<List<User>>UserList();
}
