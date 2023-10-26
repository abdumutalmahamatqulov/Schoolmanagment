using Mapster;
using Microsoft.EntityFrameworkCore;
using Schoolmanagment.Date;
using Schoolmanagment.Dto_s;
using Schoolmanagment.Entities;
using Schoolmanagment.Interface;

namespace Schoolmanagment.Services;
public class DerictorService : IDerictorRepository
{
    private readonly AppDbContext _appDbContext;

    public DerictorService(AppDbContext appDbContext) => _appDbContext = appDbContext;

    public async Task<Director> CreateDirector(DirectorDto directorDto)
    {
        var createdirector = directorDto.Adapt<Director>();
        _appDbContext.Add(createdirector);
        await _appDbContext.SaveChangesAsync();
        return createdirector;
    }

    public async Task DeleteDirector(int id)
    {
        var finddirector = _appDbContext.Directors.FirstOrDefaultAsync(x => x.Id == id);
        _appDbContext.Remove(finddirector);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<List<Director>> GetAllDirector() => await _appDbContext.Directors.ToListAsync();

    public async Task<Director> GetDirectorById(int id) => await _appDbContext.Directors.FirstOrDefaultAsync(w => w.Id == id);

    public async Task<Director> UpdateDirector(int id, DirectorDto directorDto)
    {
        var findderictor = await _appDbContext.Directors.FirstOrDefaultAsync(s => s.Id == id && directorDto == directorDto);
        findderictor.Email = directorDto.Email;
        findderictor.Password = directorDto.Password;
        findderictor.SchoolNumber = directorDto.SchoolNumber;
        _appDbContext.Directors.Update(findderictor);
        await _appDbContext.SaveChangesAsync();
        return findderictor;
    }
}
