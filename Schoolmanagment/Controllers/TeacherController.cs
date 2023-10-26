using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schoolmanagment.Dto_s;
using Schoolmanagment.Filters;
using Schoolmanagment.Interface;

namespace Schoolmanagment.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "TEACHER,ADMIN")]
public class TeacherController : ControllerBase
{
    private readonly ITeacherRepository _teacherRepository;
    private readonly IValidator<TeacherDto> _validator;
    public TeacherController(ITeacherRepository teacherRepository, IValidator<TeacherDto> validator)
    {
        _teacherRepository = teacherRepository;
        _validator = validator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTeachers() => Ok(await _teacherRepository.GetAllTeacher());
    [TypeFilter(typeof(CheckInIdTeacherFilterAttribute))]
    [HttpGet("Id=Boyicha")]
    public async Task<IActionResult> GetByIdTeacher(int id) => Ok(await _teacherRepository.GetTeacherById(id));
    [HttpPost]
    public async Task<IActionResult> CreateTeacher([FromForm] TeacherDto request)
    {
        var validmodel = await _validator.ValidateAsync(request);
        if (!validmodel.IsValid) 
        {
            return BadRequest(validmodel.Errors);
        }
        return Ok(await _teacherRepository.CreateTeacher(request));
    }
    [HttpPut]
    public async Task<IActionResult> UpdateTeacher(int id, TeacherDto request) => Ok(await _teacherRepository.UpdateTeacher(id, request));
    [HttpDelete]
    public async Task<IActionResult>DeleteTeacher(int id)
    {
        await _teacherRepository.DeleteTeacher(id);
        return Ok("Delete Teacher");
    }
}
