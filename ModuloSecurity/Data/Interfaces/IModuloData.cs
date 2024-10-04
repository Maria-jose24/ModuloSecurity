using Entity.DTO;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface IModuloData
    {
        public Task Delete(int id);
        public Task LogicalDelete(int id);
        public Task<Modulo> GetById(int id);
        public Task<Modulo> Save(Modulo Modulo);
        public Task Update(Modulo Modulo);
        public Task<IEnumerable<ModuloDto>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}