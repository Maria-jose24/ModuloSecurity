using Entity.DTO;
using Entity.Model.Security;

namespace Business.Interfaces
{
    public interface IPersonBusiness
    {
        Task<IEnumerable<PersonDto>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();

        Task<PersonDto> GetById(int id);

        Task<Person>Save(PersonDto entity);

        Task Update(PersonDto entity);

        Task Delete(int id);
    }
}
