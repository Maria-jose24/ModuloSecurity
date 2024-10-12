using Entity.DTO;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface IRoleData
    {
        public Task Delete(int id);
        public Task LogicalDelete(int id); 
        public Task<Role> GetById(int id);
        public Task<Role> Save(Role Role);
        public Task Update(Role Role);
        public Task<IEnumerable<Role>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}