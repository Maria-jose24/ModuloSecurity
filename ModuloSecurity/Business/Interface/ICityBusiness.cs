using Entity.DTO;
using Entity.Model.Security;

namespace Business.Interface
{
    public interface ICityBusiness
    {
        Task Delete(int id);
        Task LogicalDelete(int id);
        Task<CityDto> GetById(int id);
        Task<City> Save(CityDto entity);
        Task Update(CityDto entity);
        Task<IEnumerable<CityDto>> GetAll();
    }
}