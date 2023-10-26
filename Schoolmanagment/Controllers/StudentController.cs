using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schoolmanagment.Dto_s;
using Schoolmanagment.Filters;
using Schoolmanagment.Interface;
using Schoolmanagment.Services;

namespace Schoolmanagment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;
    private readonly IValidator<StudentDto> _validator;
    public StudentController(IStudentRepository studentRepository, IValidator<StudentDto> validator)
    {
        _studentRepository = studentRepository;
        _validator = validator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStudent() => Ok(await _studentRepository.GetAllStudent());
    [TypeFilter(typeof(CheckInIdStudentFilterAttribute))]

    [HttpGet("Id=>Boyicha oladi")]
    public async Task<IActionResult> GetStudentById(int id) => Ok(await _studentRepository.GetStudentById(id));
    [HttpPost]
    public async Task<IActionResult> CreateStudent(StudentDto student)
    {
        var validmodel = await _validator.ValidateAsync(student);
        if (!validmodel.IsValid)
        {
            return BadRequest(validmodel.Errors);
        }
        return Ok(await _studentRepository.CreateStudent(student));
    }
    [HttpPut]
    public async Task<IActionResult> UpdateStudent(int id, StudentDto student) => Ok(await _studentRepository.UpdateStudent(id, student));
    [HttpDelete]
    public async Task <IActionResult>DeleteStudent(int id)
    {
        await _studentRepository.DeleteStudent(id);
        return Ok();
    }
}


