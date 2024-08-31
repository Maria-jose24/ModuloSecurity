using Entity.DTO;
using Entity.Model.Security;

namespace Business.Interfaces
{
    public interface IModuloBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<ModuloDto>> GetAll();
        Task<ModuloDto> GetById(int id);

        Task<Modulo>Save(ModuloDto entity);

        Task Update(ModuloDto entity);
    }
}
