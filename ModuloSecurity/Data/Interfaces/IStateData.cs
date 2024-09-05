using Entity.DTO;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface IStateData
    {
        public Task Delete(int id);
        public Task<State> GetById(int id);
        public Task<State> Save(State entity);
        public Task Update(State entity);
        public Task<IEnumerable<State>> GetAll();
        public Task<State> GetByName(string name);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}