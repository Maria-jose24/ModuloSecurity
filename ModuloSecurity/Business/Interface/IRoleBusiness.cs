using Entity.DTO;
using Entity.Model.Security;

namespace Business.Interface
{
    public interface IRoleBusiness
    {
        public Task Delete(int id);
        public Task LogicalDelete(int id);
        public Task<RoleDto> GetById(int id);
        public Task<IEnumerable<RoleDto>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<Role> Save(RoleDto entity);
        public Task Update(RoleDto entity);
    }
}