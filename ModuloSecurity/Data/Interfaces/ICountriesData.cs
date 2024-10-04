using Entity.DTO;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface ICountriesData
    {
        public Task Delete(int id);
        public Task LogicalDelete(int id);
        public Task<IEnumerable<CountriesDto>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<Countries> GetById(int id);
        public Task<Countries> Save(Countries Countries);
        public Task Update(Countries Countries);
    }
}