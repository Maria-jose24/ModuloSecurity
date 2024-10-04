using Entity.DTO;
using Entity.Model.Security;

namespace Business.Interface
{
    public interface ICountriesBusiness
    {
        public Task Delete(int id);
        public Task LogicalDelete(int id);
        public Task<IEnumerable<CountriesDto>> GetAll();
        public Task<CountriesDto> GetById(int id);
        public Task<Countries> Save(CountriesDto entity);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task Update(CountriesDto entity);
    }
}