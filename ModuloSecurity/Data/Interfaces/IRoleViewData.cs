using Entity.DTO;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface IRoleViewData
    {
        public Task Delete(int id);
        public Task LogicalDelete(int id); 
        Task<RoleView> GetById(int id);
        Task<IEnumerable<RoleView>> GetAll();
        Task<RoleView> Save(RoleView RoleView);
        Task Update(RoleView RoleView);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}