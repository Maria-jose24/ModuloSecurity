using Entity.DTO;
using Entity.Model.Security;

namespace Business.Interface
{
    public interface ICityBusiness
    {
        public Task Delete(int id);
        public Task LogicalDelete(int id);
        public Task<CityDto> GetById(int id);
        public Task<City> Save(CityDto entity);
        public Task Update(CityDto entity);
        public Task<IEnumerable<CityDto>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}