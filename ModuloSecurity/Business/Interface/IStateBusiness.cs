using Entity.DTO;
using Entity.Model.Security;

namespace Business.Interface
{
    public interface IStateBusiness
    {
        Task Delete(int id);
        Task LogicalDelete(int id);
        Task<StateDto> GetById(int id);
        Task<IEnumerable<StateDto>> GetAll();
        Task<State> Save(StateDto entity);
        Task Update(StateDto entity);
    }
}