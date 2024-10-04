using Entity.DTO;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface IUserRoleData
    {
        public Task Delete(int id);
        public Task LogicalDelete(int id);
        public Task<UserRole> GetById(int id);
        public Task<IEnumerable<UserRole>> GetAll();
        public Task<UserRole> Save(UserRole userRole);
        public Task Update(UserRole userRole);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
