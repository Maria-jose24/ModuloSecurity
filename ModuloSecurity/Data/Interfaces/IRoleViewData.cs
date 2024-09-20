using Entity.DTO;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface IRoleViewData
    {
        Task Delete(int id, bool isSoftDelete = true);
        Task<RoleView> GetById(int id);
        Task<RoleView> Save(RoleView entity);
        Task Update(RoleView entity);
        Task<IEnumerable<RoleView>> GetAll();
        Task<RoleView> GetByName(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}