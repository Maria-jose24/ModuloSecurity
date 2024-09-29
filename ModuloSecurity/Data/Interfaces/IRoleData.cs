using Entity.DTO;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface IRoleData
    {
        public Task Delete(int id);
        public Task LogicalDelete(int id); 
        Task<Role> GetById(int id);
        Task<Role> Save(Role entity);
        Task Update(Role entity);
        Task<IEnumerable<RoleDto>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}