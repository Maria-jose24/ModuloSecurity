using Entity.DTO;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface ICountriesData
    {
        public Task Delete(int id);
        public Task<Countries> GetById(int id);
        public Task<Countries> Save(Countries entity);
        public Task Update(Countries entity);
        public Task<IEnumerable<Countries>> GetAll();
        public Task<Countries> GetByName(string name);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}