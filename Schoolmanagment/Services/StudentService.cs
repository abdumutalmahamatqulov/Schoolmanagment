using Mapster;
using Microsoft.EntityFrameworkCore;
using Schoolmanagment.Date;
using Schoolmanagment.Dto_s;
using Schoolmanagment.Entities;
using Schoolmanagment.Interface;

namespace Schoolmanagment.Services;
public class StudentService : IStudentRepository
{
    private readonly AppDbContext _appDbContext;

    public StudentService(AppDbContext appDbContext) => _appDbContext = appDbContext;

    public async Task<Student> CreateStudent(StudentDto studentDto)
    {
        var createstudent = studentDto.Adapt<Student>();
        _appDbContext.Students.Add(createstudent);
        await _appDbContext.SaveChangesAsync();
        return createstudent;
    }

    public async Task DeleteStudent(int id)
    {
        var findstudent = await _appDbContext.Students.FirstOrDefaultAsync(s => s.Id == id);
        _appDbContext.Students.Remove(findstudent);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<List<Student>> GetAllStudent() => await _appDbContext.Students.ToListAsync();

    public async Task<Student> GetStudentById(int id) => await _appDbContext.Students.FirstOrDefaultAsync(student => student.Id == id);

    public async Task<Student> UpdateStudent(int id, StudentDto studentDto)
    {
        var findstudent = _appDbContext.Students.FirstOrDefault(s => s.Id == id);
        findstudent.State = studentDto.State;
        findstudent.Name = studentDto.Name;
        findstudent.Status = studentDto.Status;
        findstudent.Gender = studentDto.Gender;
        findstudent.ClassNumber = studentDto.ClassNumber;
        findstudent.Addmision = studentDto.Addmision;
        _appDbContext.Students.Update(findstudent);
        await _appDbContext.SaveChangesAsync();
        return findstudent;
    }
}
