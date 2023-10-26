using Schoolmanagment.Dto_s;
using Schoolmanagment.Entities;

namespace Schoolmanagment.Interface;
public interface IDerictorRepository
{
    Task<List<Director>> GetAllDirector();
    Task<Director> GetDirectorById(int id);
    Task<Director> CreateDirector(DirectorDto directorDto);
    Task<Director> UpdateDirector(int id,DirectorDto directorDto);
    Task DeleteDirector(int id);
}
