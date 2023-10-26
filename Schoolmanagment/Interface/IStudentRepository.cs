using Schoolmanagment.Dto_s;
using Schoolmanagment.Entities;

namespace Schoolmanagment.Interface;
public interface IStudentRepository
{
    Task<List<Student>> GetAllStudent();
    Task<Student> GetStudentById(int id);
    Task<Student> CreateStudent(StudentDto studentDto);
    Task<Student> UpdateStudent(int id, StudentDto studentDto);
    Task DeleteStudent(int id);
}
