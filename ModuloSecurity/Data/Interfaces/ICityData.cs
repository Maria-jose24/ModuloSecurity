using Entity.DTO;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface ICityData
    {
        public Task Delete(int id);
        public Task<City> GetById(int id);
        public Task<City> Save(City entity);
        public Task Update(City entity);
        public Task<IEnumerable<City>> GetAll();
        public Task<City> GetByName(string name);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}