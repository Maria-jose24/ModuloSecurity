using Entity.DTO;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface IUserData
    {
        public Task Delete(int id);
        public Task LogicalDelete(int id);
        public Task<User>GetById(int id);
        public Task<IEnumerable<UserDto>> GetAll();
        public Task<User>Save(User User);
        public Task Update(User User);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
