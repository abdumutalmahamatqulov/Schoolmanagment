namespace Schoolmanagment.Entities;
public class Student:IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Addmision { get; set; }
    public string ClassNumber { get; set; }
    public string Gender { get; set; }
    public string State { get; set; }
    public string Status { get; set; }
}
