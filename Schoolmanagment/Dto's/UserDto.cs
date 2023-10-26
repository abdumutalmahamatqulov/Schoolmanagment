using Schoolmanagment.Entities;

namespace Schoolmanagment.Dto_s;
public class UserDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public ERole Role { get; set; }
    public string Password { get; set; }
}
