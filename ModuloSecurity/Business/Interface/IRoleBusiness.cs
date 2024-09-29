using Entity.DTO;
using Entity.Model.Security;

namespace Business.Interface
{
    public interface IRoleBusiness
    {
        Task Delete(int id);
        Task LogicalDelete(int id);
        Task<RoleDto> GetById(int id);
        Task<IEnumerable<RoleDto>> GetAll();
        Task<Role> Save(RoleDto entity);
        Task Update(RoleDto entity);
    }
}
