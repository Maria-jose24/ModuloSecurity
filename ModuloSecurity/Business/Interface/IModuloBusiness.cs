using Entity.DTO;
using Entity.Model.Security;

namespace Business.Interface
{
    public interface IModuloBusiness
    {
        Task Delete(int id);
        Task LogicalDelete(int id);
        Task<ModuloDto> GetById(int id);
        Task<IEnumerable<ModuloDto>> GetAll();
        Task<Modulo>Save(ModuloDto entity);
        Task Update(ModuloDto entity);
    }
}
