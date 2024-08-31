using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IPersonData
    {
        public Task Delete(int id);
        public Task<Person> GetById(int id);

        public Task<Person> Save(Person entity);

        public Task Update(Person entity);

        public Task<IEnumerable<Person>> GetAll();

        public Task<Person>GetByName(string name);

        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
