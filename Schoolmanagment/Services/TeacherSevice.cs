using Mapster;
using Microsoft.EntityFrameworkCore;
using Schoolmanagment.Date;
using Schoolmanagment.Dto_s;
using Schoolmanagment.Entities;
using Schoolmanagment.Interface;

namespace Schoolmanagment.Services;
public class TeacherSevice : ITeacherRepository
{
    private readonly AppDbContext _appDbContext;

    public TeacherSevice(AppDbContext appDbContext) => _appDbContext = appDbContext;

    public async Task<Teacher> CreateTeacher(TeacherDto teacherDto)
    {
        var createteacher = teacherDto.Adapt<Teacher>();
        _appDbContext.Teachers.Add(createteacher);
        await _appDbContext.SaveChangesAsync();
        return createteacher;
    }

    public async Task DeleteTeacher(int id)
    {
        var findteacher = await _appDbContext.Teachers.FirstOrDefaultAsync(t => t.Id == id);
        _appDbContext.Teachers.Remove(findteacher);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<List<Teacher>> GetAllTeacher() => await _appDbContext.Teachers.ToListAsync();

    public async Task<Teacher> GetTeacherById(int id) => await _appDbContext.Teachers.FirstOrDefaultAsync(s => s.Id == id);

    public async Task<Teacher> UpdateTeacher(int id, TeacherDto teacherDto)
    {
        var findteacher = _appDbContext.Teachers.FirstOrDefault(i=> i.Id == id);
        findteacher.Student = teacherDto.Student;
        findteacher.Email = teacherDto.Email;
        findteacher.Experience = teacherDto.Experience;
        findteacher.Name = teacherDto.Name;
        findteacher.Password = teacherDto.Password;
        findteacher.Salary = teacherDto.Salary;
        _appDbContext.Teachers.Update(findteacher);
        await _appDbContext.SaveChangesAsync();
        return findteacher;
    }
}
