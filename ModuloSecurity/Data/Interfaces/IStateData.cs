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
        public Task<State> Save(State State);
        public Task Update(State State);
        Task<State> GetByName(string name);
    }
}