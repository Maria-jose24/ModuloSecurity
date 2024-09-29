using Entity.DTO;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface IUserRoleData
    {
        public Task Delete(int id);
        public Task LogicalDelete(int id);
        public Task<UserRole> GetById(int id);
        public Task<IEnumerable<UserRoleDto>> GetAll();
        public Task<UserRole> Save(UserRole UserRole);
        public Task Update(UserRole UserRole);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
