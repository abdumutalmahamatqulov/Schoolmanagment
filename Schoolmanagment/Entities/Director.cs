namespace Schoolmanagment.Entities;
public class Director :IEntity
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string SchoolNumber { get; set; }
}
