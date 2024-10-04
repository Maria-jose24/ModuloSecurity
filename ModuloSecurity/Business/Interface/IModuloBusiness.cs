using Entity.DTO;
using Entity.Model.Security;

namespace Business.Interface
{
    public interface IModuloBusiness
    {
        public Task Delete(int id);
        public Task LogicalDelete(int id);
        public Task<ModuloDto> GetById(int id);
        public Task<IEnumerable<ModuloDto>> GetAll();
        public Task<Modulo>Save(ModuloDto entity);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task Update(ModuloDto entity);
    }
}
