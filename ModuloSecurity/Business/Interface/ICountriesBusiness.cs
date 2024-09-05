using Entity.DTO;
using Entity.Model.Security;

namespace Business.Interface
{
    public interface ICountriesBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<CountriesDto>> GetAll();
        Task<CountriesDto> GetById(int id);

        Task<Countries> Save(CountriesDto entity);

        Task Update(CountriesDto entity);
    }
}
