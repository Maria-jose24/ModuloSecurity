using Entity.DTO;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface IPersonData
    {
        public Task Delete(int id);
        public Task LogicalDelete(int id);
        public Task<Person> GetById(int id);
        public Task<Person> Save(Person Person);
        public Task Update(Person Person);
        public Task<IEnumerable<PersonDto>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
