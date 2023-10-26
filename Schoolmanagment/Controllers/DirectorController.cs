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
[Authorize(Roles = "DIRECTOR,ADMIN")]
public class DirectorController : ControllerBase
{
    private readonly IDerictorRepository _derictorRepository;
    private readonly IValidator<DirectorDto> _validator;

    public DirectorController(IDerictorRepository derictorRepository, IValidator<DirectorDto> validator)
    {
        _derictorRepository = derictorRepository;
        _validator = validator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDirector() => Ok(await _derictorRepository.GetAllDirector());

    [TypeFilter(typeof(CheckInIdStudentFilterAttribute))]
    [HttpGet("Id")]
    public async Task<IActionResult> GetById(int id) => Ok(await _derictorRepository.GetDirectorById(id));
    [HttpPost]
    public async Task<IActionResult> CreateDirector(DirectorDto directorDto)
    {
        var vaidatormodel = await _validator.ValidateAsync(directorDto);
        if(!vaidatormodel.IsValid)
        {
            return BadRequest(vaidatormodel.Errors);
        }
        return Ok(await _derictorRepository.CreateDirector(directorDto));
    }
    [HttpPut]
    public async Task<IActionResult> UpdateDirector(int id, DirectorDto director) => Ok(await _derictorRepository.UpdateDirector(id, director));
    [HttpDelete]
    public async Task <IActionResult>Deletedirector(int id)
    {
        await _derictorRepository.DeleteDirector(id);
        return Ok();
    }
}
