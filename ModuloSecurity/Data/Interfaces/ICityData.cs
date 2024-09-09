using Entity.DTO;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface ICityData
    {
        Task<City> GetById(int id);
        Task<City> Save(City entity);
        Task Update(City entity);
        Task<IEnumerable<City>> GetAll();
        Task<City> GetByName(string name);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task Delete(int id);
    }
}