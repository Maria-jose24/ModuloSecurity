using Entity.DTO;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface ICountriesData
    {
        Task Delete(int id);
        Task LogicalDelete(int id);
        Task<IEnumerable<CountriesDto>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Countries> GetById(int id);
        Task<Countries> Save(Countries entity);
        Task Update(Countries entity);
        Task<Countries> GetByName(string name);
    }
}