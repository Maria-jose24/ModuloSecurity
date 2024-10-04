using Entity.DTO;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface IViewData
    {
        public Task Delete(int id);
        public Task LogicalDelete(int id);
        public Task<View> GetById(int id);
        public Task<IEnumerable<View>> GetAll();
        public Task<View> Save(View View);
        public Task Update(View View);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}