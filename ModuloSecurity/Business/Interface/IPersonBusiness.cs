using Entity.DTO;
using Entity.Model.Security;

namespace Business.Interface
{
    public interface IPersonBusiness
    {
        public Task Delete(int id);
        public Task LogicalDelete(int id);
        public Task<PersonDto> GetById(int id);
        public Task<IEnumerable<PersonDto>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<Person>Save(PersonDto entity);
        public Task Update(PersonDto entity);
    }
}