using Entity.DTO;
using Entity.Model.Security;

namespace Business.Interface
{
    public interface IStateBusiness
    {
        public Task Delete(int id);
        public Task LogicalDelete(int id);
        public Task<StateDto> GetById(int id);
        public Task<IEnumerable<StateDto>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<State> Save(StateDto entity);
        public Task Update(StateDto entity);
    }
}