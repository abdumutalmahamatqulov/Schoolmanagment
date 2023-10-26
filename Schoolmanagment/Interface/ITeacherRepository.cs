using Schoolmanagment.Dto_s;
using Schoolmanagment.Entities;

namespace Schoolmanagment.Interface;
public interface ITeacherRepository
{
    Task<List<Teacher>> GetAllTeacher();
    Task<Teacher> GetTeacherById(int id);
    Task<Teacher> CreateTeacher(TeacherDto request);
    Task<Teacher> UpdateTeacher(int id, TeacherDto request);
    Task DeleteTeacher(int id);
}
