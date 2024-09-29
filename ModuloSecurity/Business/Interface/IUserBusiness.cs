using Entity.DTO;
using Entity.Model.Security;

namespace Business.Interface
{
    public interface IUserBusiness
    {
        Task Delete (int id);
        Task LogicalDelete(int id);
        Task<UserDto> GetById(int id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<User>Save(UserDto entity);
        Task Update(UserDto entity);
    }
}