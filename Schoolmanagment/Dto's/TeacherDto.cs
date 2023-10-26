using Schoolmanagment.Entities;

namespace Schoolmanagment.Dto_s;
public class TeacherDto
{
    public string Name { get; set; }
    public Student Student { get; set; }
    public string Salary { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Experience { get; set; }
}
