using Entity.DTO;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface IStateData
    {
        public Task Delete(int id);
        public Task LogicalDelete(int id);
        public Task<IEnumerable<StateDto>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<State> GetById(int id);
        public Task<State> Save(State entity);
        public Task Update(State entity);
        Task<State> GetByName(string name);
    }
}